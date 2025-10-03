using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;
using VHub.Media.Api.Contracts.Movies.Enums;
using VHub.Media.Api.Contracts.Persons.Dto;

namespace VHub.Media.Host.Mappers.Persons;

internal class PersonsMapper : IPersonsMapper
{
	public Application.Contracts.Persons.Dto.PersonDto Map(CreatePersonRequest source) =>
		source == null
		? throw new ArgumentNullException(nameof(source))
		: new Application.Contracts.Persons.Dto.PersonDto()
		{
			FullName = source.FullName,
			OriginalFullName = source.OriginalFullName,
			BirthDate = source.BirthDate,
			BirthPlace = source.BirthPlace,
			PhotoPath = source.PhotoPath,
		};

	public GetPersonResponse Map(Application.Contracts.Persons.Dto.PersonDto source) =>
		source == null
		? null
		: new GetPersonResponse
		{
			Id = source.Id,
			FullName = source.FullName,
			OriginalFullName = source.OriginalFullName,
			BirthDate = source.BirthDate,
			BirthPlace = source.BirthPlace,
			PhotoPath = source.PhotoPath,
			Movies = source.Movies.Select(Map).ToArray(),
		};

	public MovieInfoDto Map(Application.Contracts.Persons.Dto.MovieInfoDto source) =>
		source == null
		? null
		: new MovieInfoDto
		{
			Id = source.Id,
			Title = source.Title,
			PosterPath = source.PosterPath,
			ReleaseYear = source.ReleaseYear,
			MainGenre = (Genre)source.MainGenre,
		};

	public Application.Contracts.Persons.Requests.GetPersonsByFilterRequest Map(GetPersonsByFilterRequest source) =>
		source == null
		? throw new ArgumentNullException(nameof(source))
		: new Application.Contracts.Persons.Requests.GetPersonsByFilterRequest
		{
			Id = source.Id,
			FullName = source.FullName,
			OriginalFullName = source.OriginalFullName,
			BirthDate = source.BirthDate,
			BirthPlace = source.BirthPlace,
		};
}
