using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class AuthorizedPersonUpdateProfile : Profile
    {
        public AuthorizedPersonUpdateProfile()
        {
            CreateMap<AuthorizedPersonUpdateDto, AuthorizedPersonUpdate>();
            CreateMap<AuthorizedPersonUpdateDto, AuthorizedPersonWithoutLists>();
        }
    }
}
