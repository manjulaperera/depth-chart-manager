using DepthCharts.Core.Interfaces.Repositories;
using System.Data;

namespace DepthCharts.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction _transaction;

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;
        }

        public IDbConnection Connection { get; private set; }

        public void Begin()
        {
            Connection.Open();
            _transaction = Connection.BeginTransaction();
        }

        public void End()
        {
            _transaction?.Commit();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }
    }
}