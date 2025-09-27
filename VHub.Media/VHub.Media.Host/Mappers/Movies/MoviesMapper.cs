﻿using VHub.Media.Api.Contracts.Enums;
using VHub.Media.Api.Contracts.Movies.Dto;
using VHub.Media.Api.Contracts.Movies.Requests;
using VHub.Media.Api.Contracts.Movies.Responses;

namespace VHub.Media.Host.Mappers.Movies;


internal class MoviesMapper : IMoviesMapper
{
	public Application.Contracts.Data.Movies.MovieDto Map(CreateMovieRequest source) =>
		source == null
		? throw new ArgumentNullException(nameof(source))
		: new Application.Contracts.Data.Movies.MovieDto
		{
			Title = source.Title,
			OriginalTitle = source.OriginalTitle,
			DurationInMinutes = source.DurationInMinutes,
			Description = source.Description,
			Slogan = source.Slogan,
			Countries = source.Countries,
			ReleaseDate = source.ReleaseDate,
			Budget = source.Budget,
			Genres = source.Genres.Select(x => (Application.Contracts.Data.Enums.Genre)x).ToArray(),
			AgeRating = source.AgeRating,
			AverageRating = source.AverageRating,
			RatingMpaa = source.RatingMpaa,
			IsSerial = source.IsSerial,
			PosterPath = source.PosterPath,
			TrailerPath = source.TrailerPath,
			Platforms = source.Platforms,
			Persons = source.Persons.Select(Map).ToArray(),
		};

	public Application.Contracts.Data.Movies.MovieDto Map(UpdateMovieRequest source) =>
		source == null
		? throw new ArgumentNullException(nameof(source))
		: new Application.Contracts.Data.Movies.MovieDto
		{
			Id = source.Id,
			DurationInMinutes = source.DurationInMinutes,
			Description = source.Description,
			Slogan = source.Slogan,
			Budget = source.Budget,
			AgeRating = source.AgeRating,
			AverageRating = source.AverageRating,
			RatingMpaa = source.RatingMpaa,
			TrailerPath = source.TrailerPath,
			Platforms = source.Platforms,
		};

	public GetMovieResponse Map(Application.Contracts.Data.Movies.MovieDto source) =>
		source == null
		? null
		: new GetMovieResponse()
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
			Genres = source.Genres.Select(x => (Genre)x).ToArray(),
			AgeRating = source.AgeRating,
			AverageRating = source.AverageRating,
			RatingMpaa = source.RatingMpaa,
			IsSerial = source.IsSerial,
			PosterPath = source.PosterPath,
			TrailerPath = source.TrailerPath,
			Platforms = source.Platforms,
			Persons = source.Persons.Select(Map).ToArray(),
		};

	public PersonInfoDto Map(Application.Contracts.Data.Movies.PersonInfoDto source) =>
		source == null
		? null
		: new PersonInfoDto
		{
			Id = source.Id,
			Type = (PersonType)source.Type,
			FullName = source.FullName,
			CharacterName = source.CharacterName,
		};

	public Application.Contracts.Data.Movies.PersonInfoDto Map(PersonInfoDto source) =>
		source == null
		? null
		: new Application.Contracts.Data.Movies.PersonInfoDto
		{
			Id = source.Id,
			Type = (Application.Contracts.Data.Enums.PersonType)source.Type,
			FullName = source.FullName,
			CharacterName = source.CharacterName,
		};
}
