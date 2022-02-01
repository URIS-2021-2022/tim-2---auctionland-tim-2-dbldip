using AutoMapper;
using Projekat.Entities;
using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Profiles
{
    public class CommissionProfile : Profile
    {
        public CommissionProfile()
        {
            CreateMap<Commission, CommissionDto>();
            CreateMap<CommissionCreationDto, Commission>();
            CreateMap<CommissionUpdateDto, Commission>();
        }
    }
}
