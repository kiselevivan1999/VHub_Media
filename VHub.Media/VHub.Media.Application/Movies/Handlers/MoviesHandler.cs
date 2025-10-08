using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Application.Contracts.Movies.Requests;
using VHub.Media.Application.Movies.Repositories;

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

	public async Task<List<MovieDto>> GetMoviesByFilterAsync(
		GetMoviesByFilterRequest filter, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
		// return await _repository.GetByFilterAsync(filter, cancellationToken);
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
