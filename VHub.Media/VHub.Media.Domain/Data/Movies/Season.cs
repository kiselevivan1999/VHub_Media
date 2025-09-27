namespace VHub.Media.Domain.Data.Movies;

/// <summary>
/// Сезон.
/// </summary>
public class Season
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
	public Episode[] Episodes { get; set; }
}
