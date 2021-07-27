using System;

namespace DepthChartManager.Core.Dtos
{
    public class CreateLeagueDto
    {
        public Guid SportId { get; set; }
        public string Name { get; set; }
    }
}