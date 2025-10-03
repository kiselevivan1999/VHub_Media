using VHub.Media.Application.Contracts.Movies.Enums;

namespace VHub.Media.Application.Contracts.Movies.Dto;

/// <summary>
/// Фильм.
/// </summary>
public class MovieDto
{
    /// <summary>
    /// ID фильма.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Оригинальное название.
    /// </summary>
    public string? OriginalTitle { get; set; }

    /// <summary>
    /// Длительность в минутах.
    /// </summary>
    public short? DurationInMinutes { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Слоган.
    /// </summary>
    public string? Slogan { get; set; }

    /// <summary>
    /// Страна-производитель.
    /// </summary>
    public string[]? Countries { get; set; }

    /// <summary>
    /// Дата выхода.
    /// </summary>
    public DateOnly ReleaseDate { get; set; }

    /// <summary>
    /// Бюджет.
    /// </summary>
    public decimal? Budget { get; set; }

    /// <summary>
    /// Жанры.
    /// </summary>
    public Genre[] Genres { get; set; }

    /// <summary>
    /// Возрастной рейтинг.
    /// </summary>
    public string? AgeRating { get; set; }

    /// <summary>
    /// Средняя оценка.
    /// </summary>
    public double? AverageRating { get; set; }

    /// <summary>
    /// Рейтинг MPAA.
    /// </summary>
    public string? RatingMpaa { get; set; }

    /// <summary>
    /// Является сериалом.
    /// </summary>
    public bool? IsSerial { get; set; }

    /// <summary>
    /// Путь к постеру.
    /// </summary>
	public string PosterPath { get; set; }

    /// <summary>
    /// Путь к трейлеру.
    /// </summary>
    public string? TrailerPath { get; set; }

    /// <summary>
    /// Платформы.
    /// </summary>
	public string[]? Platforms { get; set; }

    /// <summary>
    /// Персоны, к которым относится этот фильм.
    /// </summary>
    public PersonInfoDto[] Persons { get; set; }
}
