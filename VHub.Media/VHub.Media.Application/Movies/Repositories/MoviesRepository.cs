using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq.Expressions;
using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Application.Movies.Mappers;
using VHub.Media.Domain.Movies;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application.Movies.Repositories;

internal class MoviesRepository : IMoviesRepository
{
	private readonly MongoDbContext _dbContext;
	private readonly IMoviesMapper _mapper;
	private readonly IConfiguration _configuration;

	public MoviesRepository(MongoDbContext dbContext, IMoviesMapper mapper, IConfiguration configuration)
	{
		_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
	}

	public async Task<string> CreateAsync(MovieDto movie, CancellationToken cancellationToken)
	{
		bool transactionsEnabled = Convert.ToBoolean(_configuration
			.GetSection("MongoDB")
			.GetSection("TransactionsEnabled")
			.Value);

		if (transactionsEnabled)
		{
			using var session = await _dbContext.StartSessionAsync(cancellationToken);
			session.StartTransaction();

			try
			{
				var id = await CreateMovieWithPersonsInfoAsync(movie, cancellationToken);
				await session.CommitTransactionAsync(cancellationToken);
				return id;
			}
			catch (Exception)
			{
				await session.AbortTransactionAsync(cancellationToken);
				throw;
			}
		}
		else
		{
			return await CreateMovieWithPersonsInfoAsync(movie, cancellationToken);
		}
	}


	public async Task DeleteAsync(string id, CancellationToken cancellationToken) =>
		await _dbContext.Movies.DeleteOneAsync(x => x.Id == id, cancellationToken);

	public async Task UpdateAsync(MovieDto movie, CancellationToken cancellationToken)
	{
		var filter = Builders<Movie>.Filter.Eq(x => x.Id, movie.Id);
		var document = _mapper.Map(movie);
		await _dbContext.Movies.ReplaceOneAsync(filter, document, cancellationToken: cancellationToken);
	}

	public async Task<MovieDto> GetAsync(string id, CancellationToken cancellationToken)
	{
		var filter = Builders<Movie>.Filter.Eq(x => x.Id, id);
		var result = await _dbContext.Movies.Find(filter).SingleOrDefaultAsync(cancellationToken);
		return _mapper.Map(result);
	}

	public async Task<List<MovieDto>> GetByFilterAsync(
		Expression<Func<Movie, bool>> filter, CancellationToken cancellationToken)
	{
		var result = await _dbContext.Movies.Find(filter).ToListAsync(cancellationToken);
		return result.ConvertAll(_mapper.Map);
	}

	private async Task<string> CreateMovieWithPersonsInfoAsync(MovieDto movie, CancellationToken cancellationToken)
	{
		var document = _mapper.Map(movie);

		// Вставка нового документа в коллекцию movies.
		await _dbContext.Movies.InsertOneAsync(
			document,
			new InsertOneOptions { Comment = "Создание фильма." },
			cancellationToken);

		// Обогащение свойства Movies у документа персоны в коллекции persons.
		if (movie.Persons.Length != 0)
		{
			var personIds = movie.Persons.Select(x => x.Id).ToList();

			// Фильтр для всех персон, которых нужно обновить
			var filter = Builders<Person>.Filter.In(p => p.Id, personIds);
			var movieInfo = new MovieInfo
			{
				Id = document.Id,
				Title = movie.Title,
				PosterPath = movie.PosterPath,
				ReleaseYear = movie.ReleaseDate.Year,
				MainGenre = (Genre)movie.Genres.First(), //todo Логика определения главного жанра фильма.
			};
			var update = Builders<Person>.Update.Push(p => p.Movies, movieInfo);
			var updateOptions = new UpdateOptions
			{
				IsUpsert = false,
				BypassDocumentValidation = false,
			};

			await _dbContext.Persons.UpdateManyAsync(
				filter,
				update,
				updateOptions,
				cancellationToken);
		}

		return document.Id;
	}
}
