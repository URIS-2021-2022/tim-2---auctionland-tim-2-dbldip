using AppUserWebAPI.Entities;
using AppUserWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Profiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserCreationDto, AppUser>();
            CreateMap<AppUser, AppUserDto>()
                .ForMember(
                    dest => dest.appUserFullName,
                    opt => opt.MapFrom(src => $"{src.appUserName} {src.appUserLastName}"));
        }
    }
}
