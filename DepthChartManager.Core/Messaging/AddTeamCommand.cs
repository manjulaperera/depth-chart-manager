using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class AddTeamCommand : IRequest<TeamDto>
    {
        public AddTeamCommand(CreateTeamDto createTeamDto)
        {
            CreateTeamDto = createTeamDto;
        }

        public CreateTeamDto CreateTeamDto { get; }
    }

    public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, TeamDto>
    {
        private readonly ISportRepository _sportRepository;

        public AddTeamCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public Task<TeamDto> Handle(AddTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var team = _sportRepository.AddTeam(request.CreateTeamDto.SportId, request.CreateTeamDto.LeagueId, request.CreateTeamDto.Name);
                return Task.FromResult(TinyMapper.Map<TeamDto>(team));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(TeamDto));
            }
        }
    }
}