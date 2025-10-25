using System.ComponentModel;

namespace VHub.Media.Api.Contracts.Movies.Enums;

/// <summary>
/// Возрастной рейтинг.
/// </summary>
public enum AgeRating
{
    /// <summary>
    /// Неизвестно.
    /// </summary>
    [Description("Неизвестно")]
    Unknown = 0,

    /// <summary>
    /// 0+. Нет возрастных ограничений.
    /// </summary>
    [Description("0+")]
    ZeroPlus = 1,

    /// <summary>
    /// 6+. Лицам до 6 лет просмотр запрещён.
    /// </summary>
    [Description("6+")]
    SixPlus = 2,

    /// <summary>
    /// 12+. Лицам до 12 лет просмотр запрещён.
    /// </summary>
    [Description("12+")]
    TwelvePlus = 3,

    /// <summary>
    /// 16+. Лицам до 16 лет просмотр запрещён.
    /// </summary>
    [Description("16+")]
    SixteenPlus = 4,

    /// <summary>
    /// 18+. Лицам до 18 лет просмотр запрещён.
    /// </summary>
    [Description("18+")]
    EighteenPlus = 5,
}