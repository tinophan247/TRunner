namespace TRunner.Domain.Models
{
    public class BaseModel
    {
        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
    }
}
