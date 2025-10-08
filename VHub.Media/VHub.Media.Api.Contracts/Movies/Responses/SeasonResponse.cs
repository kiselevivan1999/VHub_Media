namespace VHub.Media.Api.Contracts.Movies.Responses;

/// <summary>
/// Сезон.
/// </summary>
public class SeasonResponse
{
    /// <summary>
    /// Номер.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Оригинальное название.
    /// </summary>
    public string? OriginalName { get; set; }

    /// <summary>
    /// Список серий.
    /// </summary>
    public EpisodeResponse[] Episodes { get; set; }
}
