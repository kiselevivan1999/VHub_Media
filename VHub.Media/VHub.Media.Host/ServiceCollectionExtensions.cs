using Mapster;
using VHub.Media.Host.Mappers;
using VHub.Media.Host.Mappers.Movies;
using VHub.Media.Host.Mappers.Persons;

namespace VHub.Media.Host;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApiContractsMappers(this IServiceCollection services) =>
		services
		.AddTransient<IPersonsMapper, PersonsMapper>()
		.AddTransient<IMoviesMapper, MoviesMapper>();

	public static IServiceCollection AddRegisterMapper(this IServiceCollection services) =>
		services.AddSingleton(() =>
		{
			var config = new TypeAdapterConfig();
			new RegisterMapper().Register(config);
			return config;
		});
}
