namespace VHub.Media.Application.Contracts.Movies.Dto;

/// <summary>
/// Сезон.
/// </summary>
public class SeasonDto
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
    public string OriginalName { get; set; }

    /// <summary>
    /// Список серий.
    /// </summary>
    public EpisodeDto[] Episodes { get; set; }
}
