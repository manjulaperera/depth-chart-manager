using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class UpdatePlayerPositionCommand : IRequest<PlayerPositionDto>
    {
        public UpdatePlayerPositionCommand(UpdatePlayerPositionDto updatePlayerPosition)
        {
            UpdatePlayerPositionDto = updatePlayerPosition;
        }

        public UpdatePlayerPositionDto UpdatePlayerPositionDto { get; }
    }

    public class UpdatePlayerPositionCommandHandler : IRequestHandler<UpdatePlayerPositionCommand, PlayerPositionDto>
    {
        private readonly ISportRepository _sportRepository;

        public UpdatePlayerPositionCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }


        public Task<PlayerPositionDto> Handle(UpdatePlayerPositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sport = _sportRepository.UpdatePlayerPosition(request.UpdatePlayerPositionDto.SportId, request.UpdatePlayerPositionDto.LeagueId, request.UpdatePlayerPositionDto.TeamId, request.UpdatePlayerPositionDto.PlayerId, request.UpdatePlayerPositionDto.SupportingPositionId, request.UpdatePlayerPositionDto.SupportingPositionRanking);
                return Task.FromResult(TinyMapper.Map<PlayerPositionDto>(sport));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(PlayerPositionDto));
            }
        }
    }
}