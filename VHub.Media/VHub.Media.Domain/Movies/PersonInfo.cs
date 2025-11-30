using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using VHub.Media.Common.Enums;

namespace VHub.Media.Domain.Movies;

/// <summary>
/// Информация о персоне.
/// </summary>
public class PersonInfo
{
    /// <summary>
    /// ID персоны.
    /// </summary>
    [BsonRequired]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    /// <summary>
    /// Тип персоны.
    /// </summary>
    [BsonRequired]
    public PersonType Type { get; set; }

    /// <summary>
    /// Полное имя.
    /// </summary>
    [BsonRequired]
    public string FullName { get; set; }

    /// <summary>
    /// Имя персонажа.
    /// </summary>
    public string? CharacterName { get; set; }
}