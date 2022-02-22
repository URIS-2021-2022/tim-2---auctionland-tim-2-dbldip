using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ParcelUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ParcelUserProfiles
{
    public class ParcelUserProfile : Profile
    {
        public ParcelUserProfile()
        {
            CreateMap<ParcelUser, ParcelUserDto>();
            //CreateMap<ParcelUserCreationDto, ParcelUser>();
            CreateMap<ParcelUserUpdateDto, ParcelUser>();
            CreateMap<ParcelUser, ParcelUser>();
            CreateMap<ParcelUserCreation, ParcelUser>();
        }
        
    }
}
