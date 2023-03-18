namespace TRunner.Domain.Models.Options;

public class DatabaseOptions
{
    public static string JsonKey => nameof(DatabaseOptions);

    public string Server { get; set; }

    public string Database { get; set; }

    public string User { get; set; }

    public string Password { get; set; }

    public string Options { get; set; }
}
