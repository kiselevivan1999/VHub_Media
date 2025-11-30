using Microsoft.AspNetCore.Http;

namespace VHub.Media.Application.Files;

/// <summary>
/// Хэндлер для работы с файлами.
/// </summary>
public interface IFilesHandler
{
    /// <summary>
    /// Загружает файл.
    /// </summary>
    /// <param name="file">Файл.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <param name="prefix">Префикс.</param>
    /// <returns>Ключ загруженного файла.</returns>
    Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken, string? prefix = null);

    /// <summary>
    /// Возвращает файл в виде потока.
    /// </summary>
    /// <param name="key">Ключ файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Поток содержимого файла.</returns>
    Task<Stream> GetFileAsync(string key, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет файл по его ключу.
    /// </summary>
    /// <param name="key">Ключ файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Удаление успешно.</returns>
    Task<bool> DeleteFileAsync(string key, CancellationToken cancellationToken);
}