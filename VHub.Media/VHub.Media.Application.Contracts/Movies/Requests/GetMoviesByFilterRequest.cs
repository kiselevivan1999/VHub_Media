using VHub.Media.Common.Enums;

namespace VHub.Media.Application.Contracts.Movies.Requests;

/// <summary>
/// Запрос на получение фильмов по фильтру.
/// </summary>
public class GetMoviesByFilterRequest
{
    /// <summary>
    /// ID фильма.
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Название.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Страна-производитель.
    /// </summary>
    public string[]? Countries { get; set; }

    /// <summary>
    /// Начальная дата выхода.
    /// </summary>
    public DateOnly? ReleaseDateFrom { get; set; }
    
    /// <summary>
    /// Конечная дата выхода.
    /// </summary>
    public DateOnly? ReleaseDateTo { get; set; }

    /// <summary>
    /// Жанры.
    /// </summary>
    public Genre[]? Genres { get; set; }

    /// <summary>
    /// Возрастной рейтинг.
    /// </summary>
    public AgeRating? AgeRating { get; set; }

    /// <summary>
    /// Рейтинг MPAA.
    /// </summary>
    public RatingMpaa? RatingMpaa { get; set; }

    /// <summary>
    /// Является сериалом.
    /// </summary>
    public bool? IsSerial { get; set; }

    /// <summary>
    /// Платформы.
    /// </summary>
    public string[]? Platforms { get; set; }
}
