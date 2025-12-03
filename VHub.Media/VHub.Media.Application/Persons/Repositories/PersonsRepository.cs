using Mapster;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq.Expressions;
using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Application.MongoDb;
using VHub.Media.Domain.Movies;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application.Persons.Repositories;

internal class PersonsRepository : IPersonsRepository
{
    private readonly MongoDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public PersonsRepository(MongoDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<string> CreateAsync(PersonDto person, CancellationToken cancellationToken)
    {
        var newDocument = person.Adapt<Person>();
        await _dbContext.Persons.InsertOneAsync(
            newDocument,
            new InsertOneOptions { Comment = "Создание персоны." },
            cancellationToken);

        return newDocument.Id;
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        var transactionsEnabled = Convert.ToBoolean(_configuration
            .GetSection("MongoDB")
            .GetSection("TransactionsEnabled")
            .Value);

        if (transactionsEnabled)
        {
            using var session = await _dbContext.StartSessionAsync(cancellationToken);
            session.StartTransaction();

            try
            {
                await DeletePersonWithSyncMovies(id, cancellationToken);
                await session.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await session.AbortTransactionAsync(cancellationToken);
                throw;
            }
        }
        else
        {
            await DeletePersonWithSyncMovies(id, cancellationToken);
        }
    }

    public async Task<PersonDto> GetAsync(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Person>.Filter.Eq(x => x.Id, id);
        var result = await _dbContext.Persons.Find(filter).SingleOrDefaultAsync(cancellationToken);
        return result.Adapt<PersonDto>();
    }

    public async Task<PersonDto[]> GetByFilterAsync(
        Expression<Func<Person, bool>> filter, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Persons.Find(filter).ToListAsync(cancellationToken);
        return result.Adapt<PersonDto[]>();
    }

    private async Task DeletePersonWithSyncMovies(string personId, CancellationToken cancellationToken)
    {
        var deletePersonTask = _dbContext.Persons.DeleteOneAsync(x => x.Id == personId, cancellationToken);

        var filter = Builders<Movie>.Filter.Empty;
        var update = Builders<Movie>.Update.PullFilter(
            movie => movie.Persons,
            person => person.Id == personId);

        var deletePersonFromMoviesTask = _dbContext.Movies.UpdateManyAsync(
            filter, update, cancellationToken: cancellationToken);

        await Task.WhenAll(deletePersonTask, deletePersonFromMoviesTask);
    }
}