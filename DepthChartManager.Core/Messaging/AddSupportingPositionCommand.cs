using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
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
        private readonly ISportRepository _sportRepository;

        public AddSupportingPositionCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public Task<SupportingPositionDto> Handle(AddSupportingPositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supportingPosition = _sportRepository.AddSupportingPosition(request.CreateSupportingPositionDto.SportId, request.CreateSupportingPositionDto.Name);

                return Task.FromResult(TinyMapper.Map<SupportingPositionDto>(supportingPosition));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(SupportingPositionDto));
            }
        }
    }
}