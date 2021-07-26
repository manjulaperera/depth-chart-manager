using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Domain;
using System;
using System.Collections.Generic;

namespace DepthChartManager.Infrastructure.Repositories
{
    public class DepthChartItemRepository : IDepthChartItemRepository
    {
        public DepthChartItem AddDepthChartItem(int playerId, int sportPositionId, int depth)
        {
            throw new NotImplementedException();
        }

        public League AddLeague(string name)
        {
            throw new NotImplementedException();
        }

        public TeamPlayer AddPlayer(Team team, string name)
        {
            throw new NotImplementedException();
        }

        public Team AddTeam(League league, string teamName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepthChartItem> GetDepthChartItems(Team team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<League> GetLeagues()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamPlayer> GetTeamPlayers(Team team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetTeams(League league)
        {
            throw new NotImplementedException();
        }
    }
}