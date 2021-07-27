using DepthChartManager.Domain;
using System;
using System.Collections.Generic;

namespace DepthChartManager.Core.Interfaces.Repositories
{
    public interface ISportRepository
    {
        Sport AddSport(string name);

        Sport GetSport(Guid id);

        IEnumerable<Sport> GetSports();

        League AddLeague(Guid sportId, string name);

        IEnumerable<League> GetLeagues(Guid sportId);

        SupportingPosition AddSupportingPosition(Guid sportId, string name);

        SupportingPosition GetSupportingPosition(Guid sportId, string supportingPositionName);

        IEnumerable<SupportingPosition> GetSupportingPositions(Guid sportId);

        Team AddTeam(Guid sportId, Guid leagueId, string teamName);

        IEnumerable<Team> GetTeams(Guid sportId, Guid leagueId);

        Player AddPlayer(Guid sportId, Guid leagueId, Guid teamId, string name);

        IEnumerable<Player> GetPlayers(Guid sportId, Guid leagueId, Guid teamId);

        Player GetPlayer(Guid sportId, Guid leagueId, Guid teamId, string playerName);

        IEnumerable<PlayerPosition> GetPositionOfPlayers(Guid sportId, Guid leagueId, Guid teamId);

        PlayerPosition UpdatePlayerPosition(Guid sportId, Guid leagueId, Guid teamId, Guid playerId, Guid supportingPositionId, int supportingPositionRanking);

        IEnumerable<PlayerPosition> GetBackupPlayerPositions(Guid sportId, Guid leagueId, Guid teamId, Guid playerId);
    }
}