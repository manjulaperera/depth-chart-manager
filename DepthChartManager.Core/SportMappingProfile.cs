﻿using AutoMapper;
using DepthChartManager.Core.Dtos;
using DepthChartManager.Domain;

namespace DepthChartManager.Core
{
    public class SportMappingProfile : Profile
    {
        public SportMappingProfile()
        {
            CreateMap<League, LeagueDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Team, TeamDto>();
            CreateMap<PlayerPosition, PlayerPositionDto>();
            CreateMap<SupportingPosition, SupportingPositionDto>();
        }
    }
}