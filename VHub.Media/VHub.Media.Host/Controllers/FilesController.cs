using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VHub.Media.Application.Files;

namespace VHub.Media.Host.Controllers;

[ApiController]
[Route("media/files")]
[Authorize]
public class FilesController : ControllerBase
{
    private readonly IFilesHandler _filesHandler;

    public FilesController(IFilesHandler filesHandler)
    {
        _filesHandler = filesHandler;
    }

    [HttpPost("upload")]
    [RequestSizeLimit(300 * 1024 * 1024)] // Максимальный размер 300 МБ.
    [Authorize("Admin")]
    public async Task<string> UploadFile(
        [Required] IFormFile file, CancellationToken cancellationToken = default)
    {
        if (file.Length == 0)
        {
            throw new BadHttpRequestException("Пустой файл.");
        }

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".mp4" };
        var extension = Path.GetExtension(file.FileName).ToLower();

        if (!allowedExtensions.Contains(extension))
        {
            throw new BadHttpRequestException("Поддерживаются только файлы с расширениями JPG/JPEG и MP4.");
        }

        return await _filesHandler.UploadFileAsync(file, cancellationToken);
    }

    [HttpGet("download/{key}")]
    public async Task<FileStreamResult> DownloadFile(
        [Required, FromRoute] string key, CancellationToken cancellationToken = default)
    {
        var stream = await _filesHandler.GetFileAsync(key, cancellationToken);

        var contentType = key.ToLower().EndsWith(".mp4")
            ? "video/mp4"
            : "image/jpeg";

        return File(stream, contentType);
    }

    [HttpDelete("delete/{key}")]
    [Authorize("Admin")]
    public async Task<bool> DeleteFile(
        [Required, FromRoute] string key, CancellationToken cancellationToken = default) =>
        await _filesHandler.DeleteFileAsync(key, cancellationToken);
}