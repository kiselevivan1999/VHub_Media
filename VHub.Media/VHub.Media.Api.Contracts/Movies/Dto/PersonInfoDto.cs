using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts.Enums;

namespace VHub.Media.Api.Contracts.Movies.Dto;

/// <summary>
/// Информация о персоне, связанной с фильмом.
/// </summary>
public class PersonInfoDto
{
	/// <summary>
	/// ID персоны.
	/// </summary>
	[Required]
	public string Id { get; set; }

	/// <summary>
	/// Тип персоны.
	/// </summary>
	[Required]
	public PersonType Type { get; set; }

	/// <summary>
	/// Полное имя.
	/// </summary>

	public string FullName { get; set; }

    /// <summary>
    /// Имя персонажа.
    /// </summary>
    public string? CharacterName { get; set; }
}
