using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;

namespace DepthChartManager.Domain
{
    public class Sport
    {
        private List<League> _leagues = new List<League>();
        private List<SupportingPosition> _supportingPositions = new List<SupportingPosition>();

        public Sport(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.SportNameIsInvalid);

            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
        public IEnumerable<League> Leagues => _leagues.AsReadOnly();
        public IEnumerable<SupportingPosition> SupportingPositions => _supportingPositions.AsReadOnly();

        public League GetLeague(Guid id)
        {
            return _leagues.Find(l => l.Id == id);
        }

        public League AddLeague(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.LeagueNameIsInvalid);
            Contract.Requires<Exception>(!_leagues.Exists(l => string.Equals(l.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.LeagueAlreadyExists);

            var league = new League(Id, name);
            _leagues.Add(league);
            return league;
        }

        public SupportingPosition AddSupportingPosition(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.SupportPositionNameIsInvalid);
            Contract.Requires<Exception>(!_supportingPositions.Exists(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.SupportPositionAlreadyExists);

            var supportingPosition = new SupportingPosition(Id, name);
            _supportingPositions.Add(supportingPosition);
            return supportingPosition;
        }
    }
}