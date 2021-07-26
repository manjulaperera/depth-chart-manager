using DepthChartManager.Domain;
using System.Collections.Generic;

namespace DepthChartManager.Core.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Player AddPlayer(string name);

        IEnumerable<Player> GetPlayers();
    }
}