using DepthCharts.Core.Interfaces.Repositories;
using DepthCharts.Domain;
using System;
using System.Collections.Generic;

namespace DepthCharts.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Player AddPlayer(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetPlayers()
        {
            throw new NotImplementedException();
        }
    }
}