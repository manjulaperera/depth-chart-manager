using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class GetPlayerCommand : IRequest<PlayerDto>
    {
        public GetPlayerCommand(GetPlayerDto getPlayerDto)
        {
            GetPlayerDto = getPlayerDto;
        }

        public GetPlayerDto GetPlayerDto { get; }
    }

    public class GetPlayerCommandHandler : IRequestHandler<GetPlayerCommand, PlayerDto>
    {
        private readonly ISportRepository _sportRepository;

        public GetPlayerCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public Task<PlayerDto> Handle(GetPlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = _sportRepository.GetPlayer(request.GetPlayerDto.SportId, request.GetPlayerDto.LeagueId, request.GetPlayerDto.TeamId, request.GetPlayerDto.PlayerId);
                return Task.FromResult(TinyMapper.Map<PlayerDto>(player));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(PlayerDto));
            }
        }
    }
}