using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class AddPlayerCommand : IRequest<PlayerDto>
    {
        public AddPlayerCommand(CreatePlayerDto createPlayerDto)
        {
            AddPlayerDto = createPlayerDto;
        }

        public CreatePlayerDto AddPlayerDto { get; }
    }

    public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, PlayerDto>
    {
        public readonly ISportRepository _sportRepository;

        public AddPlayerCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public Task<PlayerDto> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = _sportRepository.AddPlayer(request.AddPlayerDto.SportId, request.AddPlayerDto.LeagueId, request.AddPlayerDto.TeamId, request.AddPlayerDto.Name);
                return Task.FromResult(TinyMapper.Map<PlayerDto>(player));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(PlayerDto));
            }
        }
    }
}