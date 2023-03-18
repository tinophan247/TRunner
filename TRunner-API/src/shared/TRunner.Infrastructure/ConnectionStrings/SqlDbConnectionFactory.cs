using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using TRunner.Infrastructure.Interfaces;

namespace TRunner.Infrastructure.ConnectionStrings;

public class SqlOptions
{
    public string SqlConnectionString { get; set; }
    public bool SqlUseAccessToken { get; set; }
}

public class SqlDbConnectionFactory : IDbConnectionFactory
{
    private readonly IOptions<SqlOptions> _settings;

    public SqlDbConnectionFactory(IOptions<SqlOptions> settings)
    {
        _settings = settings;
    }

    public async Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connectionString = _settings.Value.SqlConnectionString;
        var connection = new SqlConnection(connectionString);

        if (_settings.Value.SqlUseAccessToken)
        {
            var tokenRequest = new TokenRequestContext(new[] { "https://database.windows.net/.default" });
            var accessToken = await new DefaultAzureCredential().GetTokenAsync(tokenRequest, cancellationToken);
            connection.AccessToken = accessToken.Token;
        }

        await connection.OpenAsync(cancellationToken);
        return connection;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _settings.Value.SqlConnectionString;
        var connection = new SqlConnection(connectionString);

        if (_settings.Value.SqlUseAccessToken)
        {
            var tokenRequest = new TokenRequestContext(new[] { "https://database.windows.net/.default" });
            var accessToken = new DefaultAzureCredential().GetToken(tokenRequest);
            connection.AccessToken = accessToken.Token;
        }

        connection.Open();
        return connection;
    }
}
