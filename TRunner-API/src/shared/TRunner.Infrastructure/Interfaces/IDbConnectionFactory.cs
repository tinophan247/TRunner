using System.Data;

namespace TRunner.Infrastructure.Interfaces
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
        IDbConnection CreateConnection();
    }
}
