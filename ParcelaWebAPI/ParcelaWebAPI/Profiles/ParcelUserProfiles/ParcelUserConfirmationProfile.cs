using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelPartDtos;
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
            CreateMap<ParcelPartConfirmation, ParcelPartConfirmationDto>();
            CreateMap<ParcelPart, ParcelPartConfirmation>();
        }
        
    }
}
