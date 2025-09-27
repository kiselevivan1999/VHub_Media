using System.Linq.Expressions;
using VHub.Media.Application.Contracts.Data.Movies;
using VHub.Media.Domain.Data.Movies;

namespace VHub.Media.Application.Movies.Repositories;

internal interface IMoviesRepository
{
	Task<string> CreateAsync(MovieDto movie, CancellationToken cancellationToken);

	Task UpdateAsync(MovieDto movie, CancellationToken cancellationToken);

	Task DeleteAsync(string id, CancellationToken cancellationToken);

	Task<MovieDto> GetAsync(string id, CancellationToken cancellationToken);

	Task<List<MovieDto>> GetByFilterAsync(
		Expression<Func<Movie, bool>> filter, CancellationToken cancellationToken);
}
