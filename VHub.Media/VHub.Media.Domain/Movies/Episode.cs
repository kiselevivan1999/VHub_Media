﻿namespace VHub.Media.Domain.Movies;

/// <summary>
/// Серия сериала.
/// </summary>
public class Episode
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
