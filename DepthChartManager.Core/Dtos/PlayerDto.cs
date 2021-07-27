using System;

namespace DepthChartManager.Core.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public Guid LeagueId { get; set; }
        public Guid TeamId { get; set; }
        public string Name { get; set; }
    }
}