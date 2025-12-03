using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using VHub.Media.Domain.Movies;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application.MongoDb;

public class MongoDbContext
{
    private readonly IMongoDatabase _db;
    public IMongoCollection<Movie> Movies { get; }
    public IMongoCollection<Person> Persons { get; }

    public MongoDbContext(IConfiguration configuration)
    {
        var mongoConfig = configuration.GetSection("MongoDB");
        var conn = mongoConfig["ConnectionString"];
        var dbName = mongoConfig["DatabaseName"];

        if (string.IsNullOrEmpty(conn) || string.IsNullOrEmpty(dbName))
        {
            throw new ArgumentException("Конфигурация MongoDB не найдена.");
        }

        var client = new MongoClient(conn);
        _db = client.GetDatabase(dbName);
        Movies = _db.GetCollection<Movie>("movies");
        Persons = _db.GetCollection<Person>("persons");
    }

    public async Task<IClientSessionHandle> StartSessionAsync(CancellationToken cancellationToken)
    {
        return await _db.Client.StartSessionAsync(cancellationToken: cancellationToken);
    }
}