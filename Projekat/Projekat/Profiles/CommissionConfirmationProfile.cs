using AutoMapper;
using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Profiles
{
    public class CommissionConfirmationProfile : Profile
    {
        public CommissionConfirmationProfile()
        {
            CreateMap<CommissionConfirmation, CommissionConfirmationDto>();
            CreateMap<Commission, CommissionConfirmationDto>();
            CreateMap<Commission, CommissionConfirmation>();
        }
    }
}
