using VHub.Media.Api.Contracts.Movies.Requests;
using VHub.Media.Api.Contracts.Movies.Responses;

namespace VHub.Media.Api.Contracts.Controllers;

public interface IMoviesController
{
	Task<string> CreateMovieWithPersonsAsync(CreateMovieRequest request, CancellationToken cancellationToken);

	Task UpdateMovieAsync(UpdateMovieRequest request, CancellationToken cancellationToken);

	Task DeleteMovieByIdAsync(string id, CancellationToken cancellationToken);

	Task<GetMovieResponse> GetMovieByIdAsync(string id, CancellationToken cancellationToken);

	Task<List<GetMovieResponse>> GetMoviesByFilterAsync(
		GetMoviesByFilterRequest filter, CancellationToken cancellationToken);
}
