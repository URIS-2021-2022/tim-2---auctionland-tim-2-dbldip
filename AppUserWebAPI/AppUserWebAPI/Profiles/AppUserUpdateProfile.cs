using AppUserWebAPI.Entities;
using AppUserWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Profiles
{
    public class AppUserUpdateProfile : Profile
    {
        public AppUserUpdateProfile()
        {
            CreateMap<AppUserUpdateDto, AppUserUpdate>();
            CreateMap<AppUserUpdate, AppUser>();
        }
    }
}
