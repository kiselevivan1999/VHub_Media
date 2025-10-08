using System.ComponentModel.DataAnnotations;

namespace VHub.Media.Api.Contracts.Persons.Requests;

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
	[DataType(DataType.Date)]
	public DateOnly? BirthDate { get; set; }

	/// <summary>
	/// Место рождения.
	/// </summary>
	public string? BirthPlace { get; set; }
}
