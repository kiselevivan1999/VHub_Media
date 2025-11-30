namespace VHub.Media.Application.Contracts.Persons.Dto;

/// <summary>
/// Персона.
/// </summary>
public class PersonDto
{
    /// <summary>
    /// ID персоны.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Полное имя.
    /// </summary>
    public required string FullName { get; set; }

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

    /// <summary>
    /// Фильмы, к которым относится данная персона.
    /// </summary>
    public MovieInfoDto[]? Movies { get; set; }
}