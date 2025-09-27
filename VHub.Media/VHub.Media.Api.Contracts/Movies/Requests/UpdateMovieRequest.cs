using System.ComponentModel.DataAnnotations;

namespace VHub.Media.Api.Contracts.Movies.Requests;

/// <summary>
/// Запрос на обновление фильма.
/// </summary>
public class UpdateMovieRequest
{
	/// <summary>
	/// ID фильма, информацию о котором необходимо обновить.
	/// </summary>
	[Required]
	public string Id { get; set; }

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
	/// Бюджет.
	/// </summary>
	public decimal? Budget { get; set; }

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
	public string? RatingMpaa { get; set; } //todo Возможно нужно убрать, т.к. устанавливается экспертной комиссией до выхода фильма и скорее всего никогда не меняется.

	/// <summary>
	/// Путь к трейлеру.
	/// </summary>
	public string? TrailerPath { get; set; }

	/// <summary>
	/// Платформы.
	/// </summary>
	public string[]? Platforms { get; set; }
}
