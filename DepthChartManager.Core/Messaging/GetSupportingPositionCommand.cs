using DepthChartManager.Core.Dtos;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using Nelibur.ObjectMapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class GetSupportingPositionCommand : IRequest<SupportingPositionDto>
    {
        public GetSupportingPositionCommand(GetSupportingPositionDto supportingPositionDto)
        {
            SupportingPositionDto = supportingPositionDto;
        }

        public GetSupportingPositionDto SupportingPositionDto { get; }
    }

    public class GetSupportingPositionCommandHandler : IRequestHandler<GetSupportingPositionCommand, SupportingPositionDto>
    {
        private readonly ISportRepository _sportRepository;

        public GetSupportingPositionCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public Task<SupportingPositionDto> Handle(GetSupportingPositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var supportingPosition = _sportRepository.GetSupportingPosition(request.SupportingPositionDto.SportId, request.SupportingPositionDto.SupportingPositionName);
                return Task.FromResult(TinyMapper.Map<SupportingPositionDto>(supportingPosition));
            }
            catch (Exception ex)
            {
                return Task.FromResult(default(SupportingPositionDto));
            }
        }
    }
}