using System.Linq.Expressions;
using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application.Persons.Repositories;

public interface IPersonsRepository
{
    Task<string> CreateAsync(PersonDto person, CancellationToken cancellationToken);

    Task DeleteAsync(string id, CancellationToken cancellationToken);

    Task<PersonDto> GetAsync(string id, CancellationToken cancellationToken);

    Task<PersonDto[]> GetByFilterAsync(Expression<Func<Person, bool>> filter, CancellationToken cancellationToken);
}