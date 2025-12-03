using MongoDB.Bson.Serialization.Attributes;

namespace VHub.Media.Domain.Movies;

/// <summary>
/// Серия сериала.
/// </summary>
public class Episode
{
    /// <summary>
    /// Номер.
    /// </summary>
    [BsonRequired]
    public int Number { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    [BsonRequired]
    public string Name { get; set; }

    /// <summary>
    /// Оригинальное название.
    /// </summary>
    public string? OriginalName { get; set; }

    /// <summary>
    /// Дата выхода.
    /// </summary>
    public DateOnly? ReleaseDate { get; set; }
}