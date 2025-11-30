using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Application.Contracts.Movies.Requests;

namespace VHub.Media.Application.Movies.Handlers;

public interface IMoviesHandler
{
    Task<string> CreateMovieWithPersonsInfoAsync(MovieDto movie, CancellationToken cancellationToken);

    Task UpdateMovieWithPersonsAsync(MovieDto movie, CancellationToken cancellationToken);

    Task DeleteMovieByIdAsync(string id, CancellationToken cancellationToken);

    Task<MovieDto> GetMovieByIdAsync(string id, CancellationToken cancellationToken);

    Task<MovieDto[]> GetMoviesByFilterAsync(
        GetMoviesByFilterRequest filter, CancellationToken cancellationToken);
}