using FluentAssertions;
using VHub.Media.Application.Contracts.Movies.Dto;
using VHub.Media.Application.Contracts.Movies.Requests;
using VHub.Media.Application.Movies.Handlers;
using VHub.Media.Application.Movies.Producers;
using VHub.Media.Application.Movies.Repositories;
using VHub.Media.Tests.Infrastructure;
using Xunit;

namespace VHub.Media.Tests.IntegrationTests.Movies;

[Trait("Category", "Integration")]
public class MoviesHandlerTests : IClassFixture<MongoDbMoviesFixture>
{
    private readonly MoviesHandler _handler;

    public MoviesHandlerTests(MongoDbMoviesFixture moviesFixture)
    {
        var repository = new MoviesRepository(moviesFixture.DbContext, moviesFixture.Configuration);
        var producer = new MovieCreatedProducer(null); // todo Поправить продюсера
        _handler = new MoviesHandler(repository, producer);
    }

    [Theory]
    [MemberData(nameof(MoviesTestCases.TestCases), MemberType = typeof(MoviesTestCases))]
    public async Task GetMoviesByFilter_Success(GetMoviesByFilterRequest request, MovieDto[] expectedResult)
    {
        // Act
        var actualResult = await _handler.GetMoviesByFilterAsync(request, CancellationToken.None);

        // Assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
}