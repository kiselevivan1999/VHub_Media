using VHub.Media.Common.Enums;

namespace VHub.Media.Common.Dto;

/// <summary>
/// Информация о персоне.
/// </summary>
public class PersonInfoDto
{
    /// <summary>
    /// ID персоны.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Тип персоны.
    /// </summary>
    public PersonType Type { get; set; }

    /// <summary>
    /// Полное имя.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Имя персонажа.
    /// </summary>
    public string CharacterName { get; set; }
}
