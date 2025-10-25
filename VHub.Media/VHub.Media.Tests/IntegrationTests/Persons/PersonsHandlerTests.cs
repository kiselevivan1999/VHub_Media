using FluentAssertions;
using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Application.Contracts.Persons.Requests;
using VHub.Media.Application.Persons.Handlers;
using VHub.Media.Application.Persons.Repositories;
using VHub.Media.Tests.Infrastructure;
using Xunit;

namespace VHub.Media.Tests.IntegrationTests.Persons;

[Trait("Category", "Integration")]
public class PersonsHandlerTests : IClassFixture<MongoDbPersonsFixture>
{
    private readonly PersonsHandler _handler;

    public PersonsHandlerTests(MongoDbPersonsFixture personsFixture)
    {
        var repository = new PersonsRepository(personsFixture.DbContext, personsFixture.Configuration);
        _handler = new PersonsHandler(repository);
    }

    [Theory]
    [MemberData(nameof(PersonsTestCases.TestCases), MemberType = typeof(PersonsTestCases))]
    public async Task GetPersonsByFilter_Success(GetPersonsByFilterRequest request, PersonDto[] expectedResult)
    {
        // Act
        var actualResult = await _handler.GetPersonsByFilterAsync(request, CancellationToken.None);

        // Assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
}