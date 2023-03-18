using Microsoft.AspNetCore.Http;
using TRunner.Domain.Models.Enums;

namespace TRunner.Domain.Models.Request
{
    public class CreateSportRequest
    {
        public string? SportName { get; set; }
        public int SportTypeId { get; set; }
        public bool IsActive { get; set; }
        public ImageInfo? Image { get; set; }
    }
}
