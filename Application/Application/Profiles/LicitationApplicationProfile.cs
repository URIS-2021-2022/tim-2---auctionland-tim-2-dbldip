using Application.Entities;
using Application.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class LicitationApplicationProfile : Profile
    {
        public LicitationApplicationProfile()
        {
            CreateMap<LicitationApplication, LicitationApplicationDto>();
            CreateMap<LicitationApplicationCreationDto, LicitationApplication>();
            CreateMap<LicitationApplicationUpdateDto, LicitationApplication>();
            CreateMap<LicitationApplication, LicitationApplication>();
        }
    }
}
