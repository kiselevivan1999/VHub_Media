using LinqKit;
using MongoDB.Driver;
using System.Data.Entity;
using System.Linq.Expressions;
using VHub.Media.Application.Contracts.Persons.Dto;
using VHub.Media.Application.Contracts.Persons.Requests;
using VHub.Media.Application.Persons.Repositories;
using VHub.Media.Domain.Persons;

namespace VHub.Media.Application.Persons.Handlers;

internal class PersonsHandler : IPersonsHandler
{
	private readonly IPersonsRepository _repository;

	public PersonsHandler(IPersonsRepository repository)
	{
		_repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	public async Task<string> CreatePersonAsync(PersonDto person, CancellationToken cancellationToken) =>
		await _repository.CreateAsync(person, cancellationToken);

	public async Task DeletePersonByIdAsync(string id, CancellationToken cancellationToken) =>
		await _repository.DeleteAsync(id, cancellationToken);

	public async Task<PersonDto> GetPersonByIdAsync(string id, CancellationToken cancellationToken) =>
		await _repository.GetAsync(id, cancellationToken);

	public async Task<PersonDto[]> GetPersonsByFilterAsync(
		GetPersonsByFilterRequest filter, CancellationToken cancellationToken)
	{
		if (filter == null)
		{
			return Array.Empty<PersonDto>();
		}

		if (!string.IsNullOrWhiteSpace(filter.Id))
		{
			return [await GetPersonByIdAsync(filter.Id, cancellationToken)];
		}

		if (string.IsNullOrWhiteSpace(filter.FullName) && string.IsNullOrWhiteSpace(filter.OriginalFullName))
		{
			return Array.Empty<PersonDto>();
		}

		// Фильтр по имени с OR логикой.
		var nameFilter = PredicateBuilder.New<Person>(false);

		if (!string.IsNullOrWhiteSpace(filter.FullName))
		{
			nameFilter = nameFilter.Or(p => p.FullName.Contains(filter.FullName));
		}

		if (!string.IsNullOrWhiteSpace(filter.OriginalFullName))
		{
			nameFilter = nameFilter.Or(p => p.OriginalFullName.Contains(filter.OriginalFullName));
		}

		// Последовательные добавочные фильтры с AND логикой.
		Expression<Func<Person, bool>> finalFilter = nameFilter;

		if (filter.BirthDate != null)
		{
			finalFilter = finalFilter.And(person => person.BirthDate == filter.BirthDate);
		}

		if (!string.IsNullOrWhiteSpace(filter.BirthPlace))
		{
			finalFilter = finalFilter.And(person => person.BirthPlace.Contains(filter.BirthPlace));
		}

		return await _repository.GetByFilterAsync(finalFilter, cancellationToken);
	}
}
