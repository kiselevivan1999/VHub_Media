using System.ComponentModel;

namespace VHub.Media.Common.Enums;

/// <summary>
/// Тип персоны.
/// </summary>
public enum PersonType
{
    /// <summary>
    /// Неизвестно.
    /// </summary>
    [Description("Неизвестно")] Unknown = 0,

    /// <summary>
    /// Актер.
    /// </summary>
    [Description("Актер")] Actor = 1,

    /// <summary>
    /// Сценарист.
    /// </summary>
    [Description("Сценарист")] Screenwriter = 2,

    /// <summary>
    /// Продюсер.
    /// </summary>
    [Description("Продюсер")] Producer = 3,

    /// <summary>
    /// Режиссёр.
    /// </summary>
    [Description("Режиссёр")] Director = 4,

    /// <summary>
    /// Композитор.
    /// </summary>
    [Description("Композитор")] Composer = 5,

    /// <summary>
    /// Оператор.
    /// </summary>
    [Description("Оператор")] Cinematographer = 6,

    /// <summary>
    /// Монтажёр.
    /// </summary>
    [Description("Монтажёр")] Editor = 7,
}