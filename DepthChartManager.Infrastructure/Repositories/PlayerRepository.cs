using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartManager.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private Dictionary<int, string> _playersMap = new Dictionary<int, string>();

        public void AddPlayer(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && !_playersMap.Values.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                var id = _playersMap.Count + 1;
                _playersMap[id] = name;
            }

            throw new Exception();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _playersMap.Select(kvp => new Player
            {
                Id = kvp.Key,
                Name = kvp.Value
            });
        }
    }
}