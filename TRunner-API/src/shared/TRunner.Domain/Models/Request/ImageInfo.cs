namespace TRunner.Domain.Models.Request;

public class ImageInfo
{
    public string Base64 { get; set; }
    public string? Extension { get; set; } = "png";
}
