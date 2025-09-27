namespace VHub.Media.Application.Contracts.Data.Persons;

public class GetPersonsByFilterRequest
{
	/// <summary>
	/// ID персоны.
	/// </summary>
	public string? Id { get; set; }

	/// <summary>
	/// Полное имя.
	/// </summary>
	public string? FullName { get; set; }

	/// <summary>
	/// Оригинальное полное имя.
	/// </summary>
	public string? OriginalFullName { get; set; }

	/// <summary>
	/// Дата рождения.
	/// </summary>
	public DateOnly? BirthDate { get; set; }

	/// <summary>
	/// Место рождения.
	/// </summary>
	public string? BirthPlace { get; set; }
}
