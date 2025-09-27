using VHub.Media.Application.Contracts.Data.Movies;
using VHub.Media.Domain.Data.Movies;

namespace VHub.Media.Application.Movies.Mappers;

/// <summary>
/// Маппер для работы с фильмами.
/// </summary>
internal interface IMoviesMapper
{
	EpisodeDto Map(Episode source);

	Episode Map(EpisodeDto source);

	MovieDto Map(Movie source);

	Movie Map(MovieDto source);

	PersonInfoDto Map(PersonInfo source);
	
	PersonInfo Map(PersonInfoDto source);

	SeasonDto Map(Season source);
	
	Season Map(SeasonDto source);
}
