using System;

namespace DepthChartManager.Core.Dtos
{
    public class CreatePlayerDto
    {
        public Guid SportId { get; set; }
        public Guid LeagueId { get; set; }
        public Guid TeamId { get; set; }
        public string Name { get; set; }
    }
}