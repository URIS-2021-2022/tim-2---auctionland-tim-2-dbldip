using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelProfiles
{
    public class ParcelConfirmationProfile : Profile
    {
        public ParcelConfirmationProfile()
        {
            CreateMap<ParcelConfirmation, ParcelConfirmationDto>();
            CreateMap<Parcel, ParcelConfirmation>();
        }
    }
}
