using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;

namespace DepthChartManager.Domain
{
    public class League
    {
        private List<Team> _teams = new List<Team>();

        public League(Guid sportId, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.LeagueNameIsInvalid);
            Id = Guid.NewGuid();
            SportId = sportId;
            Name = name;
        }

        public Guid Id { get; }
        public Guid SportId { get; }
        public string Name { get; }
        public IEnumerable<Team> Teams => _teams.AsReadOnly();

        public Team GetTeam(Guid id)
        {
            return _teams.Find(t => t.Id == id);
        }

        public Team AddTeam(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.TeamNameIsInvalid);
            Contract.Requires<Exception>(!_teams.Exists(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.TeamAlreadyExists);

            var team = new Team(SportId, Id, name);
            _teams.Add(team);
            return team;
        }
    }
}