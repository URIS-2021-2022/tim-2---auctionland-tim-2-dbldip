using AppUserWebAPI.Entities;
using AppUserWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Profiles
{
    public class TypeOfUserProfile : Profile
    {
        public TypeOfUserProfile()
        {
            CreateMap<TypeOfUser, TypeOfUserDto>();
        }
    }
}
