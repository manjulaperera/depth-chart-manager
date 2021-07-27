using AutoMapper;
using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public UpdatePlayerPositionCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<PlayerPositionDto> Handle(UpdatePlayerPositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sport = _sportRepository.UpdatePlayerPosition(request.UpdatePlayerPositionDto.SportId, request.UpdatePlayerPositionDto.LeagueId, request.UpdatePlayerPositionDto.TeamId, request.UpdatePlayerPositionDto.PlayerId, request.UpdatePlayerPositionDto.SupportingPositionId, request.UpdatePlayerPositionDto.SupportingPositionRanking);
                return Task.FromResult(_mapper.Map<PlayerPositionDto>(sport));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(PlayerPositionDto));
            }
        }
    }
}