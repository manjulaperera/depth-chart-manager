using AutoMapper;
using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class AddSupportingPositionCommand : IRequest<SupportingPositionDto>
    {
        public AddSupportingPositionCommand(CreateSupportingPositionDto createSupportingPositionDto)
        {
            CreateSupportingPositionDto = createSupportingPositionDto;
        }

        public CreateSupportingPositionDto CreateSupportingPositionDto { get; }
    }

    public class AddSupportingPositionCommandHandler : IRequestHandler<AddSupportingPositionCommand, SupportingPositionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public AddSupportingPositionCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<SupportingPositionDto> Handle(AddSupportingPositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supportingPosition = _sportRepository.AddSupportingPosition(request.CreateSupportingPositionDto.SportId, request.CreateSupportingPositionDto.Name);

                return Task.FromResult(_mapper.Map<SupportingPositionDto>(supportingPosition));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(SupportingPositionDto));
            }
        }
    }
}