using System;

namespace DepthChartManager.Core.Dtos
{
    public class GetBackupPlayersDto
    {
        public Guid LeagueId { get; set; }
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }
    }
}