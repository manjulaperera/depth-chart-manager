using DepthChartManager.Helpers;
using System;

namespace DepthChartManager.Domain
{
    public class Player
    {
        public Player(League league, Team team, string name)
        {
            Contract.Requires<Exception>(league != null, Resource.LeagueNameIsInvalid);
            Contract.Requires<Exception>(team != null, Resource.TeamNameIsInvalid);
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);

            Id = Guid.NewGuid();
            League = league;
            Team = team;
            Name = name;
        }

        public Guid Id { get; }

        public League League { get; }

        public Team Team { get; }

        public string Name { get; }
    }
}