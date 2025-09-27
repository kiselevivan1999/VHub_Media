using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VHub.Media.Application.Movies.Handlers;
using VHub.Media.Application.Movies.Mappers;
using VHub.Media.Application.Movies.Repositories;
using VHub.Media.Application.Persons.Handlers;
using VHub.Media.Application.Persons.Mappers;
using VHub.Media.Application.Persons.Repositories;

namespace VHub.Media.Application;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
		=> services
		.AddMongoDb(configuration)
		.AddPersonsAppServices()
		.AddMoviesAppServices();

	private static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
		=> services
		.AddSingleton(_ => new MongoDbContext(configuration));

	private static IServiceCollection AddPersonsAppServices(this IServiceCollection services)
		=> services
		.AddScoped<IPersonsRepository, PersonsRepository>()
		.AddScoped<IPersonsHandler, PersonsHandler>()
		.AddSingleton<IPersonsMapper, PersonsMapper>();

	private static IServiceCollection AddMoviesAppServices(this IServiceCollection services)
		=> services
		.AddScoped<IMoviesRepository, MoviesRepository>()
		.AddScoped<IMoviesHandler, MoviesHandler>()
		.AddSingleton<IMoviesMapper, MoviesMapper>();
}