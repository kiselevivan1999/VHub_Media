using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Application.Contracts.Persons.Requests;

namespace VHub.Media.Application.Persons.Handlers;

public interface IPersonsHandler
{
	Task<string> CreatePersonAsync(PersonDto person, CancellationToken cancellationToken);

	Task DeletePersonByIdAsync(string id, CancellationToken cancellationToken);

	Task<PersonDto> GetPersonByIdAsync(string id, CancellationToken cancellationToken);

	Task<PersonDto[]> GetPersonsByFilterAsync(
		GetPersonsByFilterRequest filter, CancellationToken cancellationToken);
}
