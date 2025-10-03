namespace VHub.Media.Application.Contracts.Movies.Dto;

/// <summary>
/// Серия сериала.
/// </summary>
public class EpisodeDto
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
    /// Дата выхода.
    /// </summary>
    public DateOnly ReleaseDate { get; set; }

}
