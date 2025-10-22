using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using VHub.Media.Application;
using VHub.Media.Domain.Movies;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Tests.Infrastructure;

public class MongoDbFixture : IDisposable
{
    public IConfiguration Configuration { get; }
    public MongoDbContext DbContext { get; }

    public MongoDbFixture()
    {
        var configDict = new Dictionary<string, string>
        {
            { "MongoDB:ConnectionString", "mongodb://localhost:27017" },
            { "MongoDB:DatabaseName", "test-db" }
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(configDict!)
            .Build();

        Configuration = configuration;
        DbContext = new MongoDbContext(Configuration);
        SeedData();
    }

    private void SeedData()
    {
        DbContext.Movies.DeleteMany(Builders<Movie>.Filter.Empty);
        DbContext.Persons.DeleteMany(Builders<Person>.Filter.Empty);

        var testPersons = new[]
        {
            new Person
            {
                Id = "68e559937976667bf6608d0f",
                FullName = "Сэди Синк",
                OriginalFullName = "Sadie Sink",
                BirthDate = new DateOnly(2002, 4, 16),
                BirthPlace = "Бренхем, Техас, США",
            },
            new Person
            {
                Id = "68e559930a581027464db21e",
                FullName = "Сэди Фрост",
                OriginalFullName = "Sadie Frost",
                BirthDate = new DateOnly(1965, 6, 19),
                BirthPlace = "Лондон, Англия, Великобритания",
            },
            new Person
            {
                Id = "68e5599346f2cc0231fc833a",
                FullName = "Сэди Сэндлер",
                OriginalFullName = "Sadie Sandler",
                BirthDate = new DateOnly(2006, 5, 6),
                BirthPlace = "Лос-Анджелес, Калифорния, США",
            },
            new Person
            {
                Id = "68e55993f66a3a9837595eb0",
                FullName = "Сэди Стэнли",
                OriginalFullName = "Sadie Stanley",
                BirthDate = new DateOnly(2001, 11, 15),
                BirthPlace = "Колумбия, Южная Каролина, США",
            },
            new Person
            {
                Id = "68e55993650cc39470b6979e",
                FullName = "Том Харди",
                OriginalFullName = "Tom Hardy",
                BirthDate = new DateOnly(1977, 9, 15),
                BirthPlace = "Лондон, Англия, Великобритания",
            },
            new Person
            {
                Id = "68e55993b24832c3a69515b8",
                FullName = "Том Круз",
                OriginalFullName = "Tom Cruise",
                BirthDate = new DateOnly(1962, 7, 3),
                BirthPlace = "Сиракьюс, Нью-Йорк, США",
            },
            new Person
            {
                Id = "68e559937d9924b58991cbd4",
                FullName = "Том Хэнкс",
                OriginalFullName = "Tom Hanks",
                BirthDate = new DateOnly(1956, 7, 9),
                BirthPlace = "Конкорд, Калифорния, США",
            },
            new Person
            {
                Id = "68e559933162afba60b1946d",
                FullName = "Том Холланд",
                OriginalFullName = "Tom Holland",
                BirthDate = new DateOnly(1996, 6, 1),
                BirthPlace = "Кингстон-апон-Темс, Большой Лондон, Великобритания",
            },
            new Person
            {
                Id = "68e5599303ad9306b67d7a8f",
                FullName = "Том Хиддлстон",
                OriginalFullName = "Tom Hiddleston",
                BirthDate = new DateOnly(1981, 2, 9),
                BirthPlace = "Лондон, Англия, Великобритания",
            },
            new Person
            {
                Id = "68e559935959704f1c0e4fce",
                FullName = "Эмма Стоун",
                OriginalFullName = "Emma Stone",
                BirthDate = new DateOnly(1988, 11, 6),
                BirthPlace = "Скоттсдейл, Аризона, США",
            },
            new Person
            {
                Id = "68e55d24fad0cfb0a9990cef",
                FullName = "Тоби Магуайр",
                OriginalFullName = "Tobey Maguire",
                BirthDate = new DateOnly(1975, 6, 27),
                BirthPlace = "Санта-Моника, Калифорния, США",
            },
        };

        DbContext.Persons.InsertMany(testPersons);
    }

    public void Dispose()
    {
    }
}