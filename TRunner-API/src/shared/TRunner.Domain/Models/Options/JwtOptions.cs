namespace TRunner.Domain.Models.Options;

public class JwtOptions
{
    public static string JsonKey => nameof(JwtOptions);
    public string Secret { get; set; }
}
