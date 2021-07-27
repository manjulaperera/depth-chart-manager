using DepthChartManager.Core.Dtos;
using DepthChartManager.Domain;
using Nelibur.ObjectMapper;

namespace DepthChartManager.Core
{
    public class AutoMapper
    {
        public AutoMapper()
        {
            TinyMapper.Bind<Sport, SportDto>();
            TinyMapper.Bind<League, LeagueDto>();
            TinyMapper.Bind<Player, PlayerDto>();
            TinyMapper.Bind<Team, TeamDto>();
            TinyMapper.Bind<PlayerPosition, PlayerPositionDto>();
            TinyMapper.Bind<SupportingPosition, SupportingPositionDto>();

        }
    }
}
