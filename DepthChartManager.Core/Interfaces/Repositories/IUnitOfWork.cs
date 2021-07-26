using System;
using System.Data;

namespace DepthChartManager.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }

        void Begin();

        void End();
    }
}