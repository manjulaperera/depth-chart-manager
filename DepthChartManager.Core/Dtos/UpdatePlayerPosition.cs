namespace DepthChartManager.Core.Dtos
{
    public class UpdatePlayerPosition
    {
        public int PlayerId { get; set; }
        public int PositionId { get; set; }
        public int Depth { get; set; }
    }
}
