using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application.Persons.Mappers;

public interface IPersonsMapper
{
	MovieInfoDto Map(MovieInfo source);

	MovieInfo Map(MovieInfoDto source);

	PersonDto Map(Person source);

	Person Map(PersonDto source);
}
