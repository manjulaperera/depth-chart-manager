using DepthCharts.Domain;
using System.Collections.Generic;

namespace DepthCharts.Core.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Player AddPlayer(string name);

        IEnumerable<Player> GetPlayers();
    }
}