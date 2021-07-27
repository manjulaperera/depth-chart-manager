using AutoMapper;
using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
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
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public GetPlayerCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<PlayerDto> Handle(GetPlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = _sportRepository.GetPlayer(request.GetPlayerDto.SportId, request.GetPlayerDto.LeagueId, request.GetPlayerDto.TeamId, request.GetPlayerDto.PlayerName);
                return Task.FromResult(_mapper.Map<PlayerDto>(player));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(PlayerDto));
            }
        }
    }
}