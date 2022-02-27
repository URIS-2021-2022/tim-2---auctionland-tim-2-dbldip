using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelPartDtos;
using ParcelaWebAPI.Models.ParcelUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelUserProfiles
{
    public class ParcelUserConfirmationProfile : Profile
    {
        public ParcelUserConfirmationProfile()
        {
            CreateMap<ParcelUserCreation, ParcelUserConfirmation>();
            CreateMap<ParcelUserConfirmation, ParcelUserConfirmationDto>();
            CreateMap<ParcelUser, ParcelUserConfirmation>();
        }
        
    }
}
