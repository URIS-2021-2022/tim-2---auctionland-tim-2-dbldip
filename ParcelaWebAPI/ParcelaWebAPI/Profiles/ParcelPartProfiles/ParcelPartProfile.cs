using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelPartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelPartProfiles
{
    public class ParcelPartProfile : Profile
    {
        public ParcelPartProfile()
        {
            CreateMap<ParcelPart, ParcelPartDto>();
            CreateMap<ParcelPartUpdateDto, ParcelPart>();
            CreateMap<ParcelPart, ParcelPart>();
            CreateMap<ParcelPartCreation, ParcelPart>();
        }
        
    }
}
