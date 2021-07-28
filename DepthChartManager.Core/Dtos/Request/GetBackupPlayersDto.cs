using System;

namespace DepthChartManager.Core.Dtos.Request
{
    public class GetBackupPlayersDto
    {
        public Guid LeagueId { get; set; }

        public Guid TeamId { get; set; }

        public Guid PlayerId { get; set; }

        public Guid SupportingPositionId { get; set; }
    }
}