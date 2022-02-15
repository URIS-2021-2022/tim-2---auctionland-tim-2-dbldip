using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelPartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelPartProfiles
{
    public class ParcelPartConfirmationProfile : Profile
    {
        public ParcelPartConfirmationProfile()
        {
            CreateMap<ParcelPartConfirmation, ParcelPartConfirmationDto>();
            CreateMap<ParcelPart, ParcelPartConfirmation>();
        }
    }
}
