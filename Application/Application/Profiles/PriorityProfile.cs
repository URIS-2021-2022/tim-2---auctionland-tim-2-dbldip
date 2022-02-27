using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entities;
using Application.Models;
using AutoMapper;

namespace Application.Profiles
{
    public class PriorityProfile : Profile
    {
        public PriorityProfile()
        {
            CreateMap<Priority, PriorityDto>();
            CreateMap<PriorityDto, Priority>();
            CreateMap<Priority, Priority>();
        }
    }
}
