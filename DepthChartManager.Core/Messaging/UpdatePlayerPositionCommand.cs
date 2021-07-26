using DepthChartManager.Core.Dtos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class UpdatePlayerPositionCommand : IRequest
    {
        public UpdatePlayerPositionCommand(UpdatePlayerPosition updatePlayerPosition)
        {
            UpdatePlayerPosition = updatePlayerPosition;
        }

        public UpdatePlayerPosition UpdatePlayerPosition { get; }
    }

    public class UpdatePlayerPositionCommandHandler : IRequestHandler<UpdatePlayerPositionCommand>
    {
        public Task<Unit> Handle(UpdatePlayerPositionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
