using DepthChartManager.Core.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Interfaces.Services
{
    public interface IDepthChartService
    {
        Task<LeagueDto> AddLeague(string leagueName);

        Task<SupportingPositionDto> AddSupportingPosition(Guid leagueId, string supportingPositionName);

        Task<TeamDto> AddTeam(Guid leagueId, string teamName);

        Task<PlayerDto> AddPlayer(Guid leagueId, Guid teamId, string playerName);

        Task<PlayerDto> GetPlayer(Guid leagueId, Guid teamId, string playerName);

        Task<SupportingPositionDto> GetSupportingPosition(Guid leagueId, string supportingPositionName);

        Task<IEnumerable<PlayerPositionDto>> GetPlayerPositions(Guid leagueId, Guid teamId);

        Task<IEnumerable<PlayerPositionDto>> GetBackupPlayerPositions(Guid leagueId, Guid teamId, Guid playerId, Guid supportingPositionId);

        Task<PlayerPositionDto> UpdatePlayerPosition(Guid leagueId, Guid teamId, Guid playerId, Guid supportingPositionId, int supportingPositionRanking);
    }
}