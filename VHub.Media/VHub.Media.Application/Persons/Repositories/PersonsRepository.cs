using MongoDB.Driver;
using System.Linq.Expressions;
using VHub.Media.Application.Contracts.Data.Persons;
using VHub.Media.Application.Persons.Mappers;
using VHub.Media.Domain.Data.Persons;

namespace VHub.Media.Application.Persons.Repositories;

internal class PersonsRepository : IPersonsRepository
{
	private readonly MongoDbContext _dbContext;
	private readonly IPersonsMapper _mapper;

	public PersonsRepository(MongoDbContext dbContext, IPersonsMapper mapper)
	{
		_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	public async Task<string> CreateAsync(PersonDto person, CancellationToken cancellationToken)
	{
		var newDocument = _mapper.Map(person);
		await _dbContext.Persons.InsertOneAsync(
			newDocument,
			new InsertOneOptions { Comment = "Создание персоны." },
			cancellationToken);

		return newDocument.Id;
	}

	public async Task DeleteAsync(string id, CancellationToken cancellationToken) =>
		await _dbContext.Persons.DeleteOneAsync(x => x.Id == id, cancellationToken);

	public async Task<PersonDto> GetAsync(string id, CancellationToken cancellationToken)
	{
		var filter = Builders<Person>.Filter.Eq(x => x.Id, id);
		var result = await _dbContext.Persons.Find(filter).SingleOrDefaultAsync(cancellationToken);
		return _mapper.Map(result);
	}

	public async Task<PersonDto[]> GetByFilterAsync(
		Expression<Func<Person, bool>> filter, CancellationToken cancellationToken)
	{
		var result = await _dbContext.Persons.Find(filter).ToListAsync(cancellationToken);
		return result.Select(_mapper.Map).ToArray();
	}
}