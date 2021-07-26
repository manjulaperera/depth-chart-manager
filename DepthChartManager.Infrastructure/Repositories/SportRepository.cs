using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartManager.Infrastructure.Repositories
{
    public class SportRepository : ISportRepository
    {
        private Dictionary<int, string> _sportsMap = new Dictionary<int, string>();
        private Dictionary<int, List<string>> _sportPositionMap = new Dictionary<int, List<string>>();

        public void AddSport(string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && !_sportsMap.Values.Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                var id = _sportsMap.Count + 1;
                _sportsMap[id] = name;
                _sportPositionMap[id] = new List<string>();
            }

            throw new Exception();
        }

        public void AddSportPosition(int sportId, string name)
        {
            if (!string.IsNullOrWhiteSpace(name) && _sportsMap.ContainsKey(sportId) && !_sportPositionMap[sportId].Contains(name, StringComparer.OrdinalIgnoreCase))
            {
                _sportPositionMap[sportId].Add(name);
            }

            throw new Exception();
        }

        public IEnumerable<SportPosition> GetSportPositons(int sportId)
        {
            if (_sportsMap.ContainsKey(sportId))
            {
                return _sportPositionMap[sportId].Select((item, index) => new SportPosition
                {
                    Id = index,
                    Name = item,
                    SportId = sportId
                });
            }

            return Enumerable.Empty<SportPosition>();
        }

        public IEnumerable<Sport> GetSports()
        {
            return _sportsMap.Select(kvp => new Sport
            {
                Id = kvp.Key,
                Name = kvp.Value
            });
        }
    }
}