using System.Text.Json.Serialization;

namespace TRunner.Domain.Models.Response
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
        public string? DisplayName { get; set; }
        public string? ImageUrl { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
