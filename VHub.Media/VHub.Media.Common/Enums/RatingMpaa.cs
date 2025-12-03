using System.ComponentModel;

namespace VHub.Media.Common.Enums;

/// <summary>
/// Рейтинг MPAA.
/// </summary>
/// <remarks>Ассоциация MPAA (Американская Киноассоциация, Motion Picture Association of America) является родоначальницей рейтинговой системы,
/// помогающей родителям оценить, подходят ли те или иные фильмы для просмотра их детьми.</remarks>
public enum RatingMpaa
{
    /// <summary>
    /// Неизвестно.
    /// </summary>
    [Description("Неизвестно")] Unknown = 0,

    /// <summary>
    /// G. Нет возрастных ограничений.
    /// </summary>
    [Description("G")] GeneralAudiences = 1,

    /// <summary>
    /// PG. Рекомендуется присутствие родителей.
    /// </summary>
    [Description("PG")] ParentalGuidanceSuggested = 2,

    /// <summary>
    /// PG-13. Детям до 13 лет просмотр не желателен.
    /// </summary>
    [Description("PG-13")] ParentsStronglyCautioned = 3,

    /// <summary>
    /// R. Лицам до 17 лет обязательно присутствие взрослого.
    /// </summary>
    [Description("R")] Restricted = 4,

    /// <summary>
    /// NC-17. Лицам до 18 лет просмотр запрещен.
    /// </summary>
    [Description("NC-17")] NC17 = 5,
}