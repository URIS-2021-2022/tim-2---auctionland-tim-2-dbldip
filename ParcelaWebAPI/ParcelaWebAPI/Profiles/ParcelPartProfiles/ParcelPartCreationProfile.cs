using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models;
using ParcelaWebAPI.Models.ParcelPartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelPartProfiles
{
    public class ParcelPartCreationProfile : Profile
    {
        public ParcelPartCreationProfile()
        {
            CreateMap<ParcelPartCreationDto, ParcelPartCreation>();
        }
    }
}
