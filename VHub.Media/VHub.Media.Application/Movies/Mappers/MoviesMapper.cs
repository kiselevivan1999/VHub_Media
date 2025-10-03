using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Domain.Movies;

namespace VHub.Media.Application.Movies.Mappers;

internal class MoviesMapper : IMoviesMapper
{
	public EpisodeDto Map(Episode source) =>
		source == null
		? null
		: new EpisodeDto()
		{
			Number = source.Number,
			Name = source.Name,
			OriginalName = source.OriginalName,
			ReleaseDate = source.ReleaseDate,
		};

	public Episode Map(EpisodeDto source) =>
		source == null
		? null
		: new Episode()
		{
			Number = source.Number,
			Name = source.Name,
			OriginalName = source.OriginalName,
			ReleaseDate = source.ReleaseDate,
		};

	public MovieDto Map(Movie source) =>
		source == null
		? null
		: new MovieDto
		{
			Id = source.Id.ToString(),
			Title = source.Title,
			OriginalTitle = source.OriginalTitle,
			DurationInMinutes = source.DurationInMinutes,
			Description = source.Description,
			Slogan = source.Slogan,
			Countries = source.Countries,
			ReleaseDate = source.ReleaseDate,
			Budget = source.Budget,
			Genres = source.Genres.Select(x => (Contracts.Movies.Enums.Genre)x).ToArray(),
			AgeRating = source.AgeRating,
			AverageRating = source.AverageRating,
			RatingMpaa = source.RatingMpaa,
			IsSerial = source.IsSerial,
			PosterPath = source.PosterPath,
			TrailerPath = source.TrailerPath,
			Platforms = source.Platforms,
			Persons = source.Persons.Select(Map).ToArray(),
		};

	public Movie Map(MovieDto source) =>
		source == null
		? null
		: new Movie()
		{
			Id = source.Id,
			Title = source.Title,
			OriginalTitle = source.OriginalTitle,
			DurationInMinutes = source.DurationInMinutes,
			Description = source.Description,
			Slogan = source.Slogan,
			Countries = source.Countries,
			ReleaseDate = source.ReleaseDate,
			Budget = source.Budget,
			Genres = source.Genres.Select(x => (Domain.Movies.Genre)x).ToArray(),
			AgeRating = source.AgeRating,
			AverageRating = source.AverageRating,
			RatingMpaa = source.RatingMpaa,
			IsSerial = source.IsSerial,
			PosterPath = source.PosterPath,
			TrailerPath = source.TrailerPath,
			Platforms = source.Platforms,
			Persons = source?.Persons.Select(Map).ToArray(),
		};

	public PersonInfoDto Map(PersonInfo source) =>
		source == null
		? null
		: new PersonInfoDto
		{
			Id = source.Id,
			Type = (Contracts.Persons.Enums.PersonType)source.Type,
			FullName = source.FullName,
			CharacterName = source.CharacterName,
		};

	public PersonInfo Map(PersonInfoDto source) =>
		source == null
		? null
		: new PersonInfo
		{
			Id = source.Id,
			Type = (Domain.Persons.PersonType)source.Type,
			FullName = source.FullName,
			CharacterName = source.CharacterName,
		};

	public SeasonDto Map(Season source) =>
		source == null
		? null
		: new SeasonDto
		{
			Number = source.Number,
			Name = source.Name,
			OriginalName = source.OriginalName,
			Episodes = source.Episodes.Select(Map).ToArray(),
		};

	public Season Map(SeasonDto source) =>
		source == null
		? null
		: new Season
		{
			Number = source.Number,
			Name = source.Name,
			OriginalName = source.OriginalName,
			Episodes = source.Episodes.Select(Map).ToArray(),
		};
}
