using System;

namespace DepthChartManager.Core.Dtos
{
    public class UpdatePlayerPositionDto
    {
        public Guid SportId { get; set; }
        public Guid LeagueId { get; set; }
        public Guid TeamId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid SupportingPositionId { get; set; }
        public int SupportingPositionRanking { get; set; }
    }
}