using VHub.Media.Application.Contracts.Data.Movies;

namespace VHub.Media.Application.Movies.Handlers;

public interface IMoviesHandler
{
	Task<string> CreateMovieWithPersonsInfoAsync(MovieDto movie, CancellationToken cancellationToken);

	Task UpdateMovieWithPersonsAsync(MovieDto movie, CancellationToken cancellationToken);

	Task DeleteMovieByIdAsync(string id, CancellationToken cancellationToken);

	Task<MovieDto> GetMovieByIdAsync(string id, CancellationToken cancellationToken);

	Task<List<MovieDto>> GetMoviesByFilterAsync(
		GetMoviesByFilterRequest filter, CancellationToken cancellationToken);
}
