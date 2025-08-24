using Microsoft.Extensions.DependencyInjection;

namespace Infrustructure.EntityFramework;

public static class EntityFrameworkInstaller
{
    public static IServiceCollection ConfigureContext(this IServiceCollection services,
            string connectionString)
    {
        return services;
    }
}
