using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts.Persons.Enums;

namespace VHub.Media.Api.Contracts.Movies.Responses;

/// <summary>
/// Информация о персоне, связанной с фильмом.
/// </summary>
public class PersonInfoResponse
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

    [Required]
    public string FullName { get; set; }

    /// <summary>
    /// Имя персонажа.
    /// </summary>
    public string? CharacterName { get; set; }
}