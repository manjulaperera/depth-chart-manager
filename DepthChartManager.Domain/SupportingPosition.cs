using DepthChartManager.Helpers;
using System;

namespace DepthChartManager.Domain
{
    public class SupportingPosition
    {
        public SupportingPosition(Guid sportId, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.SupportPositionNameIsInvalid);
            Id = Guid.NewGuid();
            SportId = sportId;
            Name = name;
        }

        public Guid Id { get; }
        public Guid SportId { get; }
        public string Name { get; }
    }
}