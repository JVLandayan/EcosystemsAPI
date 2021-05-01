using AutoMapper;
using EcoSystemAPI.Context.Models;
using EcoSystemAPI.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoSystemAPI.core.Dtos;

namespace EcoSystemAPI.Profiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            //Source -> Target
            CreateMap<State, StateReadDto>();
            CreateMap<StateCreateDto, State>();
            CreateMap<StateUpdateDto, State>();
            CreateMap<State, StateUpdateDto>();
            
        }

    }
}
