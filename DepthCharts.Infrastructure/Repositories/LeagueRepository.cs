using DepthCharts.Core.Interfaces.Repositories;
using DepthCharts.Domain;
using System;
using System.Collections.Generic;

namespace DepthCharts.Infrastructure.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeagueRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepthChartItem AddDepthChartItem(TeamPlayer teamPlayer, SportPosition sportPosition)
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