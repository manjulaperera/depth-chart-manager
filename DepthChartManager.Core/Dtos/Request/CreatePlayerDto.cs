using System;

namespace DepthChartManager.Core.Dtos.Request
{
    public class CreatePlayerDto
    {
        public Guid LeagueId { get; set; }

        public Guid TeamId { get; set; }

        public string Name { get; set; }
    }
}