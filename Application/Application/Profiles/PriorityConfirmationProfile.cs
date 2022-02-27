using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Entities;
using Application.Models;
using AutoMapper;

namespace Application.Profiles
{
    public class PriorityConfirmationProfile : Profile
    {
        public PriorityConfirmationProfile()
        {
            CreateMap<PriorityConfirmation, PriorityConfirmationDto>();
            CreateMap<Priority, PriorityConfirmation>();
        }
    }
}
