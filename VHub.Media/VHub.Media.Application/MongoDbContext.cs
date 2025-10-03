using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using VHub.Media.Domain.Movies;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application;

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

		//Конфигурация для логирования.
		var settings = new MongoClientSettings
		{
			Server = new MongoServerAddress("localhost", 27017),
			ClusterConfigurator = cb => cb.Subscribe<CommandStartedEvent>(e =>
			{
				if (e.CommandName == "find")
				{
					Console.WriteLine($"MongoDB Query: {e.Command.ToJson()}");
				}
			})
		};

		var client = new MongoClient(settings);
		//var client = new MongoClient(conn);
		_db = client.GetDatabase(dbName);
		Movies = _db.GetCollection<Movie>("movies");
		Persons = _db.GetCollection<Person>("persons");
	}

	public async Task<IClientSessionHandle> StartSessionAsync(CancellationToken cancellationToken)
	{
		return await _db.Client.StartSessionAsync(cancellationToken: cancellationToken);
	}
}
