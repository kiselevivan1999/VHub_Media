namespace VHub.Media.Application.Files;

/// <summary>
/// Настройки для S3.
/// </summary>
public class S3Options
{
    /// <summary>
    /// URL.
    /// </summary>
    public string ServiceUrl { get; set; } = string.Empty;

    /// <summary>
    /// Ключ доступа.
    /// </summary>
    public string AccessKey { get; set; } = string.Empty;

    /// <summary>
    /// Ключ секрета.
    /// </summary>
    public string SecretKey { get; set; } = string.Empty;

    /// <summary>
    /// Название бакета.
    /// </summary>
    public string BucketName { get; set; } = string.Empty;

    /// <summary>
    /// Регион.
    /// </summary>
    public string Region { get; set; } = "us-east-1";

    /// <summary>
    /// Использовать устаревший стиль путей для файлов.
    /// </summary>
    public bool ForcePathStyle { get; set; } = true;

    /// <summary>
    /// Использовать HTTP.
    /// </summary>
    public bool UseHttp { get; set; } = true;
}