using System;

namespace DepthChartManager.Core.Dtos
{
    public class GetPlayerDto
    {
        public Guid SportId { get; set; }
        public Guid LeagueId { get; set; }
        public Guid TeamId { get; set; }
        public string PlayerName { get; set; }
    }
}