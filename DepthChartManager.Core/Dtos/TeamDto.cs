﻿using System;

namespace DepthChartManager.Core.Dtos
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public Guid SportId { get; set; }
        public Guid LeagueId { get; set; }
        public string Name { get; set; }
    }
}