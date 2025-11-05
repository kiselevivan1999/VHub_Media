using Mapster;
using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application;

public static class MapsterConfiguration
{
    public static void AddMapster()
    {
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

        TypeAdapterConfig<PersonDto, Person>.NewConfig()
            .Map(dest => dest.Movies, src =>
                MapMovies(src.Movies));
    }

    private static MovieInfo[] MapMovies(MovieInfoDto[]? movies)
    {
        return movies == null
            ? []
            : movies.Select(m => m.Adapt<MovieInfo>()).ToArray();
    }
}