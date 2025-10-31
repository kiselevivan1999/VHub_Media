using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace VHub.Media.Application.Files;

/// <summary>
/// <inheritdoc cref="IFilesHandler"/>
/// </summary>
public class FilesHandler : IFilesHandler
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;
    private readonly S3Options _s3Options;
    

    public FilesHandler(IOptions<S3Options> s3Options)
    {
       _s3Options = s3Options?.Value ?? throw new ArgumentNullException(nameof(s3Options));
        _bucketName = _s3Options.BucketName;

        var config = new AmazonS3Config
        {
            ServiceURL = _s3Options.ServiceUrl,
            ForcePathStyle = _s3Options.ForcePathStyle,
            UseHttp = _s3Options.UseHttp,
        };

        _s3Client = new AmazonS3Client(
            _s3Options.AccessKey,
            _s3Options.SecretKey,
            config
        );
    }

    public async Task<string> UploadFileAsync(IFormFile file, CancellationToken cancellationToken, string? prefix = null)
    {
        var key = string.IsNullOrEmpty(prefix) 
            ? $"{Guid.NewGuid()}_{file.FileName}"
            : $"{prefix}/{Guid.NewGuid()}_{file.FileName}";

        await using var stream = file.OpenReadStream();
        
        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = key,
            InputStream = stream,
            ContentType = file.ContentType
        };

        await _s3Client.PutObjectAsync(request, cancellationToken);
        return key;
    }

    public async Task<Stream> GetFileAsync(string key, CancellationToken cancellationToken)
    {
        var request = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = key
        };

        var response = await _s3Client.GetObjectAsync(request, cancellationToken);
        return response.ResponseStream;
    }

    public async Task<bool> DeleteFileAsync(string key, CancellationToken cancellationToken)
    {
        try
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            _ = await _s3Client.DeleteObjectAsync(request, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }
}