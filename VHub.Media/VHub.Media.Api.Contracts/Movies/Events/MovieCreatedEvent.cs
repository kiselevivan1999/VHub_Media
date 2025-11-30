using VHub.Media.Api.Contracts.Movies.Enums;
using VHub.Media.Api.Contracts.Persons;

namespace VHub.Media.Api.Contracts.Movies.Events;

/// <summary>
/// Событие о создании фильма.
/// </summary>
public class MovieCreatedEvent
{
    /// <summary>
    /// ID фильма.
    /// </summary>
    public string MovieId { get; set; }

    /// <summary>
    /// Название фильма.
    /// </summary>
    public string MovieTitle { get; set; }

    /// <summary>
    /// Жанры.
    /// </summary>
    public Genre[] Genres { get; set; } = [];

    /// <summary>
    /// IDs персон.
    /// </summary>
    public string[] PersonIds { get; set; } = [];

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}