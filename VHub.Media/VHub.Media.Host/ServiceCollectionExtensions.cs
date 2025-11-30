using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using KafkaFlow;
using VHub.Media.Application.Files;

namespace VHub.Media.Host;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddS3Service(this IServiceCollection services, IConfiguration configuration)
        => services
            .Configure<S3Options>(configuration.GetSection("S3Options"))
            .AddScoped<IFilesHandler, FilesHandler>();

    public static IServiceCollection AddAuthenticationAndAuthorizationService(
        this IServiceCollection services, IConfiguration configuration)
    {
        string authorizationIdentityServerUri = configuration.GetValue<string>("IdentityUrlName")!;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            JwtBearerDefaults.AuthenticationScheme, conf =>
            {
                conf.Authority = authorizationIdentityServerUri;
                conf.RequireHttpsMetadata = false;

                conf.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromSeconds(40),
                    ValidateAudience = false,
                };
            });

        services.AddAuthorization(conf =>
        {
            conf.AddPolicy("Admin", policy =>
            {
                policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                policy.RequireClaim(ClaimTypes.Role, "admin");
            });
        });

        return services;
    }

    public static IServiceCollection AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
    {
        string authorizationIdentityServerUri = configuration.GetValue<string>("IdentityUrlName") + "connect/token";

        services.AddSwaggerGen(conf =>
        {
            conf.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    Password = new OpenApiOAuthFlow()
                    {
                        TokenUrl = new Uri(authorizationIdentityServerUri)
                    },
                },
            });

            conf.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });

        return services;
    }

    public static IApplicationBuilder UseKafkaBus(this IApplicationBuilder app, IHostApplicationLifetime lifetime)
    {
        var kafkaBus = app.ApplicationServices.CreateKafkaBus();

        lifetime.ApplicationStarted.Register(async () =>
        {
            try
            {
                await kafkaBus.StartAsync(lifetime.ApplicationStopping);
                Console.WriteLine("Kafka bus started successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start Kafka bus: {ex.Message}");
            }
        });

        lifetime.ApplicationStopping.Register(() => { kafkaBus.StopAsync().GetAwaiter().GetResult(); });

        return app;
    }
}