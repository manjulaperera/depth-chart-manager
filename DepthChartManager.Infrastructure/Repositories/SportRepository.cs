using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Domain;
using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;

namespace DepthChartManager.Infrastructure.Repositories
{
    public class SportRepository : ISportRepository
    {
        private List<Sport> _sports = new List<Sport>();

        public Sport AddSport(string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.SportNameIsInvalid);
            Contract.Requires<Exception>(!_sports.Exists(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.SportsAlreadyExists);

            var sport = new Sport(name);
            _sports.Add(sport);
            return sport;
        }

        public Sport GetSport(Guid sportId)
        {
            return _sports.Find(s => s.Id == sportId);
        }

        public IEnumerable<Sport> GetSports()
        {
            return _sports.AsReadOnly();
        }

        public League AddLeague(Guid sportId, string name)
        {
            return GetSport(sportId)?.AddLeague(name);
        }

        public IEnumerable<League> GetLeagues(Guid sportId)
        {
            return GetSport(sportId)?.Leagues;
        }

        public SupportingPosition AddSupportingPosition(Guid sportId, string name)
        {
            return GetSport(sportId)?.AddSupportingPosition(name);
        }

        public IEnumerable<SupportingPosition> GetSupportingPositions(Guid sportId)
        {
            return GetSport(sportId)?.SupportingPositions;
        }

        public Team AddTeam(Guid sportId, Guid leagueId, string teamName)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.AddTeam(teamName);
        }

        public IEnumerable<Team> GetTeams(Guid sportId, Guid leagueId)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.Teams;
        }

        public Player AddPlayer(Guid sportId, Guid leagueId, Guid teamId, string name)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.GetTeam(teamId)?.AddPlayer(name);
        }

        public IEnumerable<Player> GetPlayers(Guid sportId, Guid leagueId, Guid teamId)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.GetTeam(teamId)?.Players;
        }

        public Player GetPlayer(Guid sportId, Guid leagueId, Guid teamId, Guid playerId)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.GetTeam(teamId)?.GetPlayer(playerId);
        }

        public IEnumerable<PlayerPosition> GetPositionOfPlayers(Guid sportId, Guid leagueId, Guid teamId)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.GetTeam(teamId)?.PlayerPositions;
        }

        public PlayerPosition UpdatePlayerPosition(Guid sportId, Guid leagueId, Guid teamId, Guid playerId, Guid supportingPositionId, int supportingPositionRanking)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.GetTeam(teamId)?.UpdatePlayerPosition(playerId, supportingPositionId, supportingPositionRanking);
        }

        public IEnumerable<PlayerPosition> GetBackupPlayerPositions(Guid sportId, Guid leagueId, Guid teamId, Guid playerId)
        {
            return GetSport(sportId)?.GetLeague(leagueId)?.GetTeam(teamId)?.GetBackupPlayerPositions(playerId);
        }
    }
}