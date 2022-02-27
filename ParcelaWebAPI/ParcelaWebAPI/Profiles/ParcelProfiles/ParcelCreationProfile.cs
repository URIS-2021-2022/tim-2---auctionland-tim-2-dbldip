using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models;
using ParcelaWebAPI.Models.ParcelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelProfiles
{
    public class ParcelCreationProfile : Profile
    {
        public ParcelCreationProfile()
        {
            CreateMap<ParcelCreationDto, ParcelCreation>().ReverseMap();
        }
    }
}
