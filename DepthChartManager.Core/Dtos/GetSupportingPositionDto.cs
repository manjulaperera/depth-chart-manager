using System;

namespace DepthChartManager.Core.Dtos
{
    public class GetSupportingPositionDto
    {
        public Guid SportId { get; set; }
        public string SupportingPositionName { get; set; }
    }
}