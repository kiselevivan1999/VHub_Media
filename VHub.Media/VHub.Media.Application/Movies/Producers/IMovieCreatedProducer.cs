using VHub.Media.Application.Contracts.Movies.Events;

namespace VHub.Media.Application.Movies.Producers;

/// <summary>
/// Продюсер события создания фильма.
/// </summary>
public interface IMovieCreatedProducer
{
    /// <summary>
    /// Отправляет событие о создании фильма.
    /// </summary>
    /// <param name="movieCreatedEvent">Событие о создании фильма</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Task.</returns>
    Task SendMovieCreatedEvent(MovieCreatedEvent movieCreatedEvent, CancellationToken cancellationToken);
}