using VHub.Media.Api.Contracts.Movies.Dto;
using VHub.Media.Api.Contracts.Movies.Requests;
using VHub.Media.Api.Contracts.Movies.Responses;

namespace VHub.Media.Host.Mappers.Movies;

/// <summary>
/// Маппер для работы с фильмами.
/// </summary>
public interface IMoviesMapper
{
	Application.Contracts.Data.Movies.MovieDto Map(CreateMovieRequest source);

	Application.Contracts.Data.Movies.MovieDto Map(UpdateMovieRequest source);

	GetMovieResponse Map(Application.Contracts.Data.Movies.MovieDto source);

	PersonInfoDto Map(Application.Contracts.Data.Movies.PersonInfoDto source);

	Application.Contracts.Data.Movies.PersonInfoDto Map(PersonInfoDto source);
}
