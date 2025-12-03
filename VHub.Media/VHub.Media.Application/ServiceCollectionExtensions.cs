using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using VHub.Media.Application.MongoDb;
using VHub.Media.Application.Movies.Handlers;
using VHub.Media.Application.Movies.Producers;
using VHub.Media.Application.Movies.Repositories;
using VHub.Media.Application.Persons.Handlers;
using VHub.Media.Application.Persons.Repositories;
using VHub.Media.Common.Enums;
using KafkaFlow;
using KafkaFlow.Serializer;

namespace VHub.Media.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddMongoDb(configuration)
            .AddPersonsAppServices()
            .AddMoviesAppServices()
            .AddKafkaCluster(configuration);

    private static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(_ => new MongoDbContext(configuration));

        BsonSerializer.RegisterSerializer(typeof(Genre), new EnumSerializer<Genre>());
        BsonSerializer.RegisterSerializer(typeof(AgeRating), new EnumSerializer<AgeRating>());
        BsonSerializer.RegisterSerializer(typeof(RatingMpaa), new EnumSerializer<RatingMpaa>());
        BsonSerializer.RegisterSerializer(typeof(PersonType), new EnumSerializer<PersonType>());

        return services;
    }

    private static IServiceCollection AddPersonsAppServices(this IServiceCollection services)
        => services
            .AddScoped<IPersonsRepository, PersonsRepository>()
            .AddScoped<IPersonsHandler, PersonsHandler>();

    private static IServiceCollection AddMoviesAppServices(this IServiceCollection services)
        => services
            .AddScoped<IMoviesRepository, MoviesRepository>()
            .AddScoped<IMoviesHandler, MoviesHandler>();

    private static IServiceCollection AddKafkaCluster(this IServiceCollection services, IConfiguration configuration)
    {
        var kafkaOptions = configuration.GetSection("Kafka");
        var kafkaServers = kafkaOptions.GetSection("BootstrapServers").Get<string[]>();
        var consumerGroup = kafkaOptions["GroupId"];

        if (kafkaOptions == null)
        {
            throw new ConfigurationErrorsException($"Конфигурация для Kafka не найдена.");
        }

        if (kafkaServers == null || string.IsNullOrWhiteSpace(consumerGroup))
        {
            throw new ConfigurationErrorsException($"{nameof(consumerGroup)} или {nameof(kafkaServers)} было null.");
        }

        services.AddScoped<IMovieCreatedProducer, MovieCreatedProducer>();

        return services
            .AddKafka(kafka => kafka
                .UseMicrosoftLog()
                .AddCluster(cluster => cluster
                    .WithBrokers(kafkaServers)
                    .AddProducer<MovieCreatedProducer>(producer =>
                    {
                        producer.AddMiddlewares(middlewares => middlewares
                            .AddSerializer<JsonCoreSerializer>());
                        producer.DefaultTopic("movie-created");
                    })));
    }
}