using VHub.Media.Application.Files;

namespace VHub.Media.Host;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddS3Service(this IServiceCollection services, IConfiguration configuration)
        => services
            .Configure<S3Options>(configuration.GetSection("S3Options"))
            .AddScoped<IFilesHandler, FilesHandler>();
}
