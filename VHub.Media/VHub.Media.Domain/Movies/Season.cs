using MongoDB.Bson.Serialization.Attributes;

namespace VHub.Media.Domain.Movies;

/// <summary>
/// Сезон.
/// </summary>
public class Season
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

    [BsonRequired]
    /// <summary>
    /// Список серий.
    /// </summary>
    public Episode[] Episodes { get; set; }
}
