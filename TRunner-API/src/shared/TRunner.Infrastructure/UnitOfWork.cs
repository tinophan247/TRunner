using System.Data;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Infrastructure.Interfaces;
using TRunner.Infrastructure.Repositories;

namespace TRunner.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _tran;

        public UnitOfWork(IDbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.CreateConnection();
            _tran = _connection.BeginTransaction();
        }

        public void Complete()
        {
            _tran?.Commit();
            _connection?.Close();
        }

        public void Dispose()
        {
            _tran?.Dispose();
            _connection?.Close();
        }

        public void Rollback()
        {
            _tran?.Rollback();
            _connection?.Close();
        }
    }
}
