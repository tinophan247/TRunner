namespace TRunner.Domain.Models.Response
{
    public class SportTypesResponse
    {
        public int SportTypeId { get; set; }
        public string SportTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
