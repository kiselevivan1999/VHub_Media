using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts.Controllers;
using VHub.Media.Api.Contracts.Movies.Requests;
using VHub.Media.Api.Contracts.Movies.Responses;
using VHub.Media.Application.Movies.Handlers;
using VHub.Media.Host.Mappers.Movies;

namespace VHub.Media.Host.Controllers;


[ApiController]
[Route("media/movies")]
public class MoviesController : IMoviesController
{
	private readonly IMoviesHandler _handler;
	private readonly IMoviesMapper _mapper;

	public MoviesController(IMoviesHandler handler, IMoviesMapper mapper)
	{
		_handler = handler ?? throw new ArgumentNullException(nameof(handler));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	[HttpPost("new")]
	public async Task<string> CreateMovieWithPersonsAsync(
		[Required, FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
	{
		return await _handler.CreateMovieWithPersonsInfoAsync(_mapper.Map(request), cancellationToken);
	}

	[HttpDelete("delete/{id}")]
	public async Task DeleteMovieByIdAsync(
		[Required, FromRoute] string id, CancellationToken cancellationToken)
	{
		await _handler.DeleteMovieByIdAsync(id, cancellationToken);
	}

	[HttpGet("{id}")]
	public async Task<GetMovieResponse> GetMovieByIdAsync(
		[Required, FromRoute] string id, CancellationToken cancellationToken)
	{
		var result = await _handler.GetMovieByIdAsync(id, cancellationToken);
		return _mapper.Map(result);
	}

	[HttpPost("")]
	public async Task<List<GetMovieResponse>> GetMoviesByFilterAsync(
		[FromBody] GetMoviesByFilterRequest filter, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
		//var result = await _handler.GetMoviesByFilterAsync(_mapper.Map(filter), cancellationToken);
		//return result.Select(_mapper.Map).ToList();
	}

	[HttpPut("update")]
	public async Task UpdateMovieAsync(
		[Required, FromBody] UpdateMovieRequest request, CancellationToken cancellationToken)
	{
		await _handler.UpdateMovieWithPersonsAsync(_mapper.Map(request), cancellationToken);
	}
}
