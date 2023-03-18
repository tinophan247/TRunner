namespace TRunner.Domain.Models.Request
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public int UserRoleId { get; set; }
    }
}
