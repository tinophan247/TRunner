using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minio;
using TRunner.Application.Interfaces.MinIO;
using TRunner.Domain.Extensions;
using TRunner.Domain.Models.Options;
using TRunner.Domain.Models.Request;

namespace TRunner.Infrastructure.MinIO
{
    public class MinIOService : IMinIOService
    {
        private readonly IOptionsMonitor<MinIoOptions> _options;
        private ILogger _logger;

        public MinIOService(IOptionsMonitor<MinIoOptions> options, ILoggerFactory loggerFactory)
        {
            _options = options;
            _logger = loggerFactory.CreateLogger<MinIOService>();
        }

        public async Task RemoveImages(IList<string> imageUrls)
        {
            var options = _options.CurrentValue;

            MinioClient client = new MinioClient()
                .WithEndpoint(options.Server)
                              .WithCredentials(options.AccessKey, options.SerectKey)
                              .Build();
            try
            {
                foreach (var item in imageUrls)
                {
                    string objectPath = item.Split(new string[] { $"{options.Bucket}/" }, StringSplitOptions.None).Last();

                    RemoveObjectArgs rmArgs = new RemoveObjectArgs()
                                  .WithBucket(options.Bucket)
                                  .WithObject(objectPath);

                    await client.RemoveObjectAsync(rmArgs);
                }
            }
            catch (Exception ex)
            {
                var error = $"RemoveImages - {Helpers.BuildErrorMessage(ex)}";
                _logger.LogError(error);
            }
        }

        public async Task<IList<string>> UploadImages(IList<ImageInfo> data, string folder)
        {
            var options = _options.CurrentValue;
            var imageUrls = new List<string>();

            MinioClient client = new MinioClient()
                .WithEndpoint(options.Server)
                              .WithCredentials(options.AccessKey, options.SerectKey)
                              .Build();

            foreach (var item in data)
            {
                try
                {
                    var fileName = $"{folder}_{DateTime.UtcNow:yyyyMMddHHmmss}.{item.Extension}";
                    byte[] bytes = Convert.FromBase64String(item.Base64);
                    var stream = new MemoryStream(bytes)
                    {
                        Position = 0
                    };

                    var poa = new PutObjectArgs()
                        .WithBucket(options.Bucket)
                        .WithStreamData(stream)
                        .WithObject($"{folder}/{fileName}")
                        .WithObjectSize(stream.Length)
                        .WithContentType($"image/{item.Extension}");

                    await client.PutObjectAsync(poa).ConfigureAwait(false);

                    var url = $"{options.MinIoApiDomain}/{options.Bucket}/{folder}/{fileName}";
                    imageUrls.Add(url);
                }
                catch (Exception ex)
                {
                    var error = $"UploadImages - {Helpers.BuildErrorMessage(ex)}";
                    _logger.LogError(error);
                }

            }

            return imageUrls;
        }
    }
}
