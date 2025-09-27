using VHub.Media.Api.Contracts.Persons.Requests;
using VHub.Media.Api.Contracts.Persons.Responses;
using VHub.Media.Api.Contracts.Persons.Dto;
using VHub.Media.Api.Contracts.Enums;

namespace VHub.Media.Host.Mappers.Persons;

internal class PersonsMapper : IPersonsMapper
{
	public Application.Contracts.Data.Persons.PersonDto Map(CreatePersonRequest source) =>
		source == null
		? throw new ArgumentNullException(nameof(source))
		: new Application.Contracts.Data.Persons.PersonDto()
		{
			FullName = source.FullName,
			OriginalFullName = source.OriginalFullName,
			BirthDate = source.BirthDate,
			BirthPlace = source.BirthPlace,
			PhotoPath = source.PhotoPath,
		};

	public GetPersonResponse Map(Application.Contracts.Data.Persons.PersonDto source) =>
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

	public MovieInfoDto Map(Application.Contracts.Data.Persons.MovieInfoDto source) =>
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

	public Application.Contracts.Data.Persons.GetPersonsByFilterRequest Map(GetPersonsByFilterRequest source) =>
		source == null
		? null
		: new Application.Contracts.Data.Persons.GetPersonsByFilterRequest
		{
			Id = source.Id,
			FullName = source.FullName,
			OriginalFullName = source.OriginalFullName,
			BirthDate = source.BirthDate,
			BirthPlace = source.BirthPlace,
		};
}
