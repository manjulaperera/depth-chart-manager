using DepthChartManager.Domain;
using System.Collections.Generic;

namespace DepthChartManager.Core.Interfaces.Repositories
{
    public interface IDepthChartItemRepository
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