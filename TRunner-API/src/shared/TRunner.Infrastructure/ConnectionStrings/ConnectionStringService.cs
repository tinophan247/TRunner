using Microsoft.Extensions.Options;
using TRunner.Domain.Models.Options;

namespace TRunner.Infrastructure.ConnectionStrings;

public class ConnectionStringService : IConnectionStringService
{
    private const string ConnectionStringFormat =
        "server={0};database={1};user={2};password={3};ConvertZeroDateTime=True;{4}";
    private readonly IOptionsMonitor<DatabaseOptions> _options;

    public ConnectionStringService(IOptionsMonitor<DatabaseOptions> options)
    {
        _options = options;
    }

    public string Create()
    {
        var options = _options.CurrentValue;
        return string.Format(
            ConnectionStringFormat,
            options.Server,
            options.Database,
            options.User,
            options.Password,
            options.Options);
    }
}