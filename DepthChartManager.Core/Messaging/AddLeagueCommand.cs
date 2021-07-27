using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class AddLeagueCommand : IRequest<LeagueDto>
    {
        public AddLeagueCommand(CreateLeagueDto createLeagueDto)
        {
            CreateLeagueDto = createLeagueDto;
        }

        public CreateLeagueDto CreateLeagueDto { get; }
    }

    public class AddLeagueCommandHandler : IRequestHandler<AddLeagueCommand, LeagueDto>
    {
        private readonly ISportRepository _sportRepository;

        public AddLeagueCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public Task<LeagueDto> Handle(AddLeagueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var league = _sportRepository.AddLeague(request.CreateLeagueDto.SportId, request.CreateLeagueDto.Name);
                return Task.FromResult(TinyMapper.Map<LeagueDto>(league));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(LeagueDto));
            }
        }
    }
}