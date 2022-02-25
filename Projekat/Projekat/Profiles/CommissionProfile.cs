using AutoMapper;
using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Profiles
{
    public class CommissionProfile : Profile
    {
        public CommissionProfile()
        {
            CreateMap<CommissionWithLists, CommissionDto>();
            CreateMap<Commission, Commission>();

            CreateMap<Commission, CommissionWithLists>();
            CreateMap<Commission, CommissionDto>();
            CreateMap<CommissionCreationDto, Commission>();
            CreateMap<CommissionCreationDto, CommissionCreation>();
            CreateMap<CommissionUpdateDto, Commission>();
            CreateMap<CommissionCreation, Commission>();
        }
    }
}
