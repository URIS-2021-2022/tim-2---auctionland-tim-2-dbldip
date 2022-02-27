using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models;
using ParcelaWebAPI.Models.ParcelUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelUserProfiles
{
    public class ParcelUserCreationProfile : Profile
    {
        public ParcelUserCreationProfile()
        {
            CreateMap<ParcelUserCreationDto, ParcelUserCreation>();
        }
    }
}
