using AutoMapper;
using DepthChartManager.Core.Dtos.Request;
using DepthChartManager.Core.Dtos.Response;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class GetBackupPlayersCommand : IRequest<CommandResult<IEnumerable<PlayerPositionDto>>>
    {
        public GetBackupPlayersCommand(GetBackupPlayersDto getBackupPlayersDto)
        {
            GetBackupPlayersDto = getBackupPlayersDto;
        }

        public GetBackupPlayersDto GetBackupPlayersDto { get; }
    }

    public class GetBackupPlayersCommandHandler : IRequestHandler<GetBackupPlayersCommand, CommandResult<IEnumerable<PlayerPositionDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public GetBackupPlayersCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<CommandResult<IEnumerable<PlayerPositionDto>>> Handle(GetBackupPlayersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var backupPlayerPositions = _sportRepository.GetBackupPlayerPositions(request.GetBackupPlayersDto.LeagueId, request.GetBackupPlayersDto.TeamId, request.GetBackupPlayersDto.PlayerId, request.GetBackupPlayersDto.SupportingPositionId);
                return Task.FromResult(new CommandResult<IEnumerable<PlayerPositionDto>>(_mapper.Map<IEnumerable<PlayerPositionDto>>(backupPlayerPositions)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult<IEnumerable<PlayerPositionDto>>(ex.Message));
            }
        }
    }
}