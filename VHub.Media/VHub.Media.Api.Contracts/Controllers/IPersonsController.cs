using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;

namespace VHub.Media.Api.Contracts.Controllers;

public interface IPersonsController
{
	Task<string> CreatePersonAsync(CreatePersonRequest request, CancellationToken cancellationToken);

	Task DeletePersonByIdAsync(string id, CancellationToken cancellationToken);

	Task<GetPersonResponse> GetPersonByIdAsync(string id, CancellationToken cancellationToken);

	Task<List<GetPersonResponse>> GetPersonsByFilterAsync(
		GetPersonsByFilterRequest filter, CancellationToken cancellationToken);
}
