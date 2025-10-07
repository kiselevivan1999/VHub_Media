using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using VHub.Media.Common.Enums;

namespace VHub.Media.Domain.Persons;

/// <summary>
/// Информация о фильме.
/// </summary>
public class MovieInfo
{
    /// <summary>
    /// ID фильма.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonRequired]
    public string Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    [BsonRequired]
    public string Title { get; set; }

    /// <summary>
    /// Путь к постеру.
    /// </summary>
    [BsonRequired]
    public string PosterPath { get; set; }

    /// <summary>
    /// Дата выхода.
    /// </summary>
    [BsonRequired]
    public int ReleaseYear { get; set; }

    /// <summary>
    /// Жанр.
    /// </summary>
    public Genre MainGenre { get; set; }
}
