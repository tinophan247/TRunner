using Microsoft.AspNetCore.Http;
using TRunner.Domain.Models.Request;

namespace TRunner.Application.Interfaces.MinIO;

public interface IMinIOService
{
    Task<IList<string>> UploadImages(IList<ImageInfo> data, string folder);
    Task RemoveImages(IList<string> imageUrls);
}
