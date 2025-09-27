using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts.Enums;

namespace VHub.Media.Api.Contracts.Persons.Dto;

/// <summary>
/// Информация о фильме.
/// </summary>
public class MovieInfoDto
{
    /// <summary>
    /// ID фильма.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Путь к постеру.
    /// </summary>
    public string PosterPath { get; set; }

    /// <summary>
    /// Дата выхода.
    /// </summary>
    public int ReleaseYear { get; set; }

    /// <summary>
    /// Жанр.
    /// </summary>
    public Genre MainGenre { get; set; }
}
