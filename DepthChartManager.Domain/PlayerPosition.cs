using System;

namespace DepthChartManager.Domain
{
    public class PlayerPosition
    {
        public PlayerPosition(Guid sportId, Guid leagueId, Guid teamId, Guid playerId, Guid supportingPositionId, int supportingPositionRanking)
        {
            SportId = sportId;
            LeagueId = leagueId;
            TeamId = teamId;
            PlayerId = playerId;
            SupportingPositionId = supportingPositionId;
            SupportingPositionRanking = supportingPositionRanking;
        }

        public Guid SportId { get; }
        public Guid LeagueId { get; }
        public Guid TeamId { get; }
        public Guid PlayerId { get; }
        public Guid SupportingPositionId { get; }
        public int SupportingPositionRanking { get; }
    }
}