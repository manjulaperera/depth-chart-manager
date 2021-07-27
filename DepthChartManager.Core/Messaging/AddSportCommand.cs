using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class AddSportCommand : IRequest<SportDto>
    {
        public AddSportCommand(CreateSportDto createSportDto)
        {
            CreateSportDto = createSportDto;
        }

        public CreateSportDto CreateSportDto { get; }
    }

    public class AddSportCommandHandler : IRequestHandler<AddSportCommand, SportDto>
    {
        private readonly ISportRepository _sportRepository;

        public AddSportCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public Task<SportDto> Handle(AddSportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sport = _sportRepository.AddSport(request.CreateSportDto.Name);
                return Task.FromResult(TinyMapper.Map<SportDto>(sport));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(SportDto));
            }
        }
    }
}