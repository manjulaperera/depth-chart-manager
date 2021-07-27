using AutoMapper;
using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class AddSportCommand : IRequest<CommandResult<SportDto>>
    {
        public AddSportCommand(CreateSportDto createSportDto)
        {
            CreateSportDto = createSportDto;
        }

        public CreateSportDto CreateSportDto { get; }
    }

    public class AddSportCommandHandler : IRequestHandler<AddSportCommand, CommandResult<SportDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public AddSportCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<CommandResult<SportDto>> Handle(AddSportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sport = _sportRepository.AddSport(request.CreateSportDto.Name);
                return Task.FromResult(new CommandResult<SportDto>(_mapper.Map<SportDto>(sport)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult<SportDto>(ex.Message));
            }
        }
    }
}