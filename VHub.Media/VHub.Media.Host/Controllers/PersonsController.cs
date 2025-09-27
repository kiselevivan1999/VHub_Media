using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts.Controllers;
using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;
using VHub.Media.Application.Persons.Handlers;
using VHub.Media.Host.Mappers.Persons;

namespace VHub.Media.Host.Controllers;

[ApiController]
[Route("media/persons")]
public class PersonsController : ControllerBase, IPersonsController
{
	private readonly IPersonsHandler _handler;
	private readonly IPersonsMapper _mapper;

	public PersonsController(IPersonsHandler handler, IPersonsMapper mapper)
	{
		_handler = handler ?? throw new ArgumentNullException(nameof(handler));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	[HttpPost("new")]
	public async Task<string> CreatePersonAsync(
		[FromBody, Required] CreatePersonRequest request, CancellationToken cancellationToken)
	{
		return await _handler.CreatePersonAsync(_mapper.Map(request), cancellationToken);
	}

	[HttpDelete("delete/{id}")]
	public async Task DeletePersonByIdAsync(
		[FromRoute, Required] string id, CancellationToken cancellationToken)
	{
		await _handler.DeletePersonByIdAsync(id, cancellationToken);
	}

	[HttpGet("{id}")]
	public async Task<GetPersonResponse> GetPersonByIdAsync(
		[FromRoute, Required] string id, CancellationToken cancellationToken)
	{
		var result = await _handler.GetPersonByIdAsync(id, cancellationToken);
		return _mapper.Map(result);
	}

	[HttpPost("")]
	public async Task<List<GetPersonResponse>> GetPersonsByFilterAsync(
		[FromBody] GetPersonsByFilterRequest filter, CancellationToken cancellationToken)
	{
		var result = await _handler.GetPersonsByFilterAsync(_mapper.Map(filter), cancellationToken);
		return result.Select(_mapper.Map).ToList();
	}
}
