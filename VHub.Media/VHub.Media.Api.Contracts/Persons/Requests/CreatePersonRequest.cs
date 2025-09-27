using System.ComponentModel.DataAnnotations;

namespace VHub.Media.Api.Contracts.Persons.Requests;

/// <summary>
/// Запрос на создание персоны.
/// </summary>
public class CreatePersonRequest
{
    /// <summary>
    /// Полное имя.
    /// </summary>
    [Required]
    public string FullName { get; set; }

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

    /// <summary>
    /// Путь к фотографии.
    /// </summary>
    public string? PhotoPath { get; set; }
}
