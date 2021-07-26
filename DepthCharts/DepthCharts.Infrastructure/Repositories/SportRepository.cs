using DepthCharts.Core.Interfaces.Repositories;
using DepthCharts.Domain;
using System;
using System.Collections.Generic;

namespace DepthCharts.Infrastructure.Repositories
{
    public class SportRepository : ISportRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public SportRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Sport AddSport(string name)
        {
            throw new NotImplementedException();
        }

        public SportPosition AddSportPosition(Sport sport, string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportPosition> GetSportPositons(Sport sport)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sport> GetSports()
        {
            throw new NotImplementedException();
        }
    }
}