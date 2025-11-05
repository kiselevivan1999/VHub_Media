using LinqKit;
using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Application.Contracts.Movies.Requests;
using VHub.Media.Application.Movies.Repositories;
using VHub.Media.Domain.Movies;

namespace VHub.Media.Application.Movies.Handlers;

internal class MoviesHandler : IMoviesHandler
{
	private readonly IMoviesRepository _repository;

	public MoviesHandler(IMoviesRepository repository)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	public async Task<string> CreateMovieWithPersonsInfoAsync(
		MovieDto movie, CancellationToken cancellationToken)
	{
		return await _repository.CreateAsync(movie, cancellationToken);
	}

	public async Task DeleteMovieByIdAsync(string id, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(id, cancellationToken);
	}

	public async Task<MovieDto[]> GetMoviesByFilterAsync(
		GetMoviesByFilterRequest filter, CancellationToken cancellationToken)
    {
        if (filter == null)
        {
            return [];
        }

        if (!string.IsNullOrWhiteSpace(filter.Id))
        {
            return [await GetMovieByIdAsync(filter.Id, cancellationToken)];
        }
        
        var predicate = PredicateBuilder.New<Movie>(true);
        
        if (filter.Title != null)
        {
            predicate = predicate
                .And(movie =>
                    movie.Title.Contains(filter.Title) ||
                    (movie.OriginalTitle != null && movie.OriginalTitle.Contains(filter.Title)));
        }
        
        if (filter.RatingMpaa != null)
        {
            predicate = predicate.And(movie => movie.RatingMpaa == filter.RatingMpaa);
        }
        
        if (filter.AgeRating != null)
        {
            predicate = predicate.And(movie => movie.AgeRating == filter.AgeRating);
        }
        
        if (filter.IsSerial != null)
        {
            predicate = predicate.And(movie => movie.IsSerial == filter.IsSerial);
        }
        
        predicate = predicate.And(movie =>
            movie.ReleaseDate >= (filter.ReleaseDateFrom ?? DateOnly.MinValue)
            && movie.ReleaseDate <= (filter.ReleaseDateTo ?? DateOnly.MaxValue));
        
        if (filter.Countries != null)
        {
            predicate = predicate.And(movie => movie.Countries.Any(country => filter.Countries.Contains(country)));
        }
        
        if (filter.Genres != null)
        {
            predicate = predicate.And(movie => movie.Genres.Any(genre => filter.Genres.Contains(genre)));
        }
        
        if (filter.Platforms != null)
        {
            predicate = predicate.And(movie => movie.Platforms != null && movie.Platforms.Any(platform => filter.Platforms.Contains(platform)));
        }
        
        return await _repository.GetByFilterAsync(predicate, cancellationToken);
	}

	public async Task<MovieDto> GetMovieByIdAsync(string id, CancellationToken cancellationToken)
	{
		return await _repository.GetAsync(id, cancellationToken);
	}

	public async Task UpdateMovieWithPersonsAsync(MovieDto movie, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(movie, cancellationToken);
	}
}
