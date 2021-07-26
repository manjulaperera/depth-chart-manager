using DepthCharts.Domain;
using System.Collections.Generic;

namespace DepthCharts.Core.Interfaces.Repositories
{
    public interface ISportRepository
    {
        Sport AddSport(string name);

        IEnumerable<Sport> GetSports();

        SportPosition AddSportPosition(Sport sport, string name);

        IEnumerable<SportPosition> GetSportPositons(Sport sport);
    }
}