using Application.Entities;
using Application.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class LicitationApplicationConfirmationProfile : Profile
    {
        public LicitationApplicationConfirmationProfile()
        {
            CreateMap<LicitationApplicationConfirmation, LicitationApplicationConfirmationDto>();
            CreateMap<LicitationApplication, LicitationApplicationConfirmation>();
        }
    }
}
