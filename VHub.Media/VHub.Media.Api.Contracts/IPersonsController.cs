using RestEase;
using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;

namespace VHub.Media.Api.Contracts;

[BasePath("media/persons")]
public interface IPersonsController
{
    [Get("new")]
    Task<string> CreatePersonAsync(
        [Required, Body] CreatePersonRequest request, CancellationToken cancellationToken);

    [Delete("delete/{id}")]
    Task DeletePersonByIdAsync(
        [Required, Path] string id, CancellationToken cancellationToken);

    [Get("{id}")]
    Task<GetPersonResponse> GetPersonByIdAsync(
        [Required, Path] string id, CancellationToken cancellationToken);

    [Post]
    Task<List<GetPersonResponse>> GetPersonsByFilterAsync(
        [Body] GetPersonsByFilterRequest filter, CancellationToken cancellationToken);
}
