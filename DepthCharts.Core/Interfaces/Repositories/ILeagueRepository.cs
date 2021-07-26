using DepthCharts.Domain;
using System.Collections.Generic;

namespace DepthCharts.Core.Interfaces.Repositories
{
    public interface ILeagueRepository
    {
        League AddLeague(string name);

        IEnumerable<League> GetLeagues();

        Team AddTeam(League league, string teamName);

        IEnumerable<Team> GetTeams(League league);

        TeamPlayer AddPlayer(Team team, string name);

        IEnumerable<TeamPlayer> GetTeamPlayers(Team team);

        DepthChartItem AddDepthChartItem(TeamPlayer teamPlayer, SportPosition sportPosition);

        IEnumerable<DepthChartItem> GetDepthChartItems(Team team);
    }
}