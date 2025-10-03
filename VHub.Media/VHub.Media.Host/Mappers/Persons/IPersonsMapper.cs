using VHub.Media.Api.Contracts.Persons.Dto;
using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;

namespace VHub.Media.Host.Mappers.Persons;

public interface IPersonsMapper
{
	Application.Contracts.Persons.Dto.PersonDto Map(CreatePersonRequest source);

	GetPersonResponse Map(Application.Contracts.Persons.Dto.PersonDto source);

    MovieInfoDto Map(Application.Contracts.Persons.Dto.MovieInfoDto source);

	Application.Contracts.Persons.Requests.GetPersonsByFilterRequest Map(GetPersonsByFilterRequest source);
}
