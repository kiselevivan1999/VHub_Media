using Mapster;
using VHub.Media.Api.Contracts.Movies.Dto;
using VHub.Media.Api.Contracts.Movies.Requests;
using VHub.Media.Api.Contracts.Movies.Responses;

namespace VHub.Media.Host.Mappers.Movies;

/// <summary>
/// Маппер для работы с фильмами.
/// </summary>
public interface IMoviesMapper
{
	Application.Contracts.Movies.Dto.MovieDto Map(CreateMovieRequest source);

	Application.Contracts.Movies.Dto.MovieDto Map(UpdateMovieRequest source);

	GetMovieResponse Map(Application.Contracts.Movies.Dto.MovieDto source);

	PersonInfoDto Map(Application.Contracts.Movies.Dto.PersonInfoDto source);

	Application.Contracts.Movies.Dto.PersonInfoDto Map(PersonInfoDto source);
}
