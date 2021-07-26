using DepthChartManager.Domain;
using System.Collections.Generic;

namespace DepthChartManager.Core.Interfaces.Repositories
{
    public interface ISportRepository
    {
        void AddSport(string name);

        IEnumerable<Sport> GetSports();

        void AddSportPosition(int sportId, string name);

        IEnumerable<SportPosition> GetSportPositons(int sportId);
    }
}