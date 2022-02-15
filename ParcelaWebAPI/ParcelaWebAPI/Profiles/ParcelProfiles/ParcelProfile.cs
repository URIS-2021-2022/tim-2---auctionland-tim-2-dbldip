using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelProfiles
{
    public class ParcelProfile : Profile
    {
        public ParcelProfile()
        {
            CreateMap<Parcel, ParcelDto>();
            CreateMap<ParcelCreationDto, Parcel>();
            CreateMap<ParcelUpdateDto, Parcel>();
            CreateMap<Parcel, Parcel>();
        }
    }
}
