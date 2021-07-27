using System;

namespace DepthChartManager.Core.Dtos
{
    public class CreateTeamDto
    {
        public Guid SportId { get; set; }
        public Guid LeagueId { get; set; }
        public string Name { get; set; }
    }
}