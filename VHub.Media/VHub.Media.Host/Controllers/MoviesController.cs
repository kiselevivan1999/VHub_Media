using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts;
using VHub.Media.Api.Contracts.Movies.Requests;
using VHub.Media.Api.Contracts.Movies.Responses;
using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Application.Movies.Handlers;

namespace VHub.Media.Host.Controllers;


[ApiController]
[Route("media/movies")]
public class MoviesController : IMoviesController
{
	private readonly IMoviesHandler _handler;

	public MoviesController(IMoviesHandler handler)
	{
		_handler = handler ?? throw new ArgumentNullException(nameof(handler));
	}

	[HttpPost("new")]
	public async Task<string> CreateMovieWithPersonsAsync(
		[Required, FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
	{
		return await _handler.CreateMovieWithPersonsInfoAsync(request.Adapt<MovieDto>(), cancellationToken);
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
		return result.Adapt<GetMovieResponse>();
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
		await _handler.UpdateMovieWithPersonsAsync(request.Adapt<MovieDto>(), cancellationToken);
	}
}
