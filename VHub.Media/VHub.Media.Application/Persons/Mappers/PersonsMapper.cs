using VHub.Media.Application.Contracts.Movies.Enums;
using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Domain.Movies;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application.Persons.Mappers;

internal class PersonsMapper : IPersonsMapper
{
	public MovieInfoDto Map(MovieInfo source) =>
		source == null
		? null
		: new MovieInfoDto
		{
			Id = source.Id,
			Title = source.Title,
			PosterPath = source.PosterPath,
			ReleaseYear = source.ReleaseYear,
			MainGenre = (Contracts.Movies.Enums.Genre)source.MainGenre,
		};

	public MovieInfo Map(MovieInfoDto source) =>
		source == null
		? null
		: new MovieInfo
		{
			Id = source.Id,
			Title = source.Title,
			PosterPath = source.PosterPath,
			ReleaseYear = source.ReleaseYear,
			MainGenre = (Domain.Movies.Genre)source.MainGenre,
		};

	public PersonDto Map(Person source) =>
		source == null
		? null
		: new PersonDto
		{
			Id = source.Id,
			FullName = source.FullName,
			OriginalFullName = source.OriginalFullName,
			BirthDate = source.BirthDate,
			BirthPlace = source.BirthPlace,
			PhotoPath = source.PhotoPath,
			Movies = source?.Movies?.Select(Map).ToArray(),
		};

	public Person Map(PersonDto source) =>
		source == null
		? null
		: new Person
		{
			Id = source.Id,
			FullName = source.FullName,
			OriginalFullName = source.OriginalFullName,
			BirthDate = source.BirthDate,
			BirthPlace = source.BirthPlace,
			PhotoPath = source.PhotoPath,
			Movies = source?.Movies?.Select(Map).ToArray() ?? [],
		};
}
