using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts;
using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;
using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Application.Persons.Handlers;

namespace VHub.Media.Host.Controllers;

[ApiController]
[Route("media/persons")]
public class PersonsController : ControllerBase, IPersonsController
{
    private readonly IPersonsHandler _handler;

    public PersonsController(IPersonsHandler handler)
    {
        _handler = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    [HttpPost("new")]
    public async Task<string> CreatePersonAsync(
        [FromBody, Required] CreatePersonRequest request, CancellationToken cancellationToken)
    {
        return await _handler.CreatePersonAsync(request.Adapt<PersonDto>(), cancellationToken);
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
        return result.Adapt<GetPersonResponse>();
    }

    [HttpPost("")]
    public async Task<List<GetPersonResponse>> GetPersonsByFilterAsync(
        [FromBody] GetPersonsByFilterRequest filter, CancellationToken cancellationToken)
    {
        var result = await _handler.GetPersonsByFilterAsync(
            filter.Adapt<Application.Contracts.Persons.Requests.GetPersonsByFilterRequest>(), cancellationToken);
        return result.Adapt<List<GetPersonResponse>>();
    }
}