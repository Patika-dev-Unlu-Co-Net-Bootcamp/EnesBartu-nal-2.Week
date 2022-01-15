using AutoMapper;
using ManagerApi.Entities;
using ManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerApi.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PlayerViewModel, Player>();
            CreateMap<Player, PlayerViewModel>();
            CreateMap<TeamViewModel, Team>();
            CreateMap<Team, TeamViewModel>();
        }
    }
}
