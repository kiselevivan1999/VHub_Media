using VHub.Media.Api.Contracts.Persons.Dto;
using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;

namespace VHub.Media.Host.Mappers.Persons;

public interface IPersonsMapper
{
	Application.Contracts.Data.Persons.PersonDto Map(CreatePersonRequest source);

	GetPersonResponse Map(Application.Contracts.Data.Persons.PersonDto source);

	MovieInfoDto Map(Application.Contracts.Data.Persons.MovieInfoDto source);

	Application.Contracts.Data.Persons.GetPersonsByFilterRequest Map(GetPersonsByFilterRequest source);
}
