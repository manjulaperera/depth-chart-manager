﻿using DepthChartManager.Helpers;
using System;

namespace DepthChartManager.Domain
{
    public class Player
    {
        public Player(Guid sportId, Guid leagueId, Guid teamId, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);
            Id = Guid.NewGuid();
            SportId = sportId;
            LeagueId = leagueId;
            TeamId = teamId;
            Name = name;
        }

        public Guid Id { get; }
        public Guid SportId { get; }
        public Guid LeagueId { get; }
        public Guid TeamId { get; }
        public string Name { get; }
    }
}