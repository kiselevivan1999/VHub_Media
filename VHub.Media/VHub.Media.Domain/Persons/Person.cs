using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VHub.Media.Domain.Persons;

/// <summary>
/// Персона.
/// </summary>
public class Person
{
    /// <summary>
    /// ID персоны.
    /// </summary>
    [BsonRequired]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>
    /// Полное имя.
    /// </summary>
    [BsonRequired]
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

    /// <summary>
    /// Фильмы, к которым относится данная персона.
    /// </summary>
    public MovieInfo[] Movies { get; set; } = [];
}