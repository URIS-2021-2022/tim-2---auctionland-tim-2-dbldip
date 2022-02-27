using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class AuthorizedPersonProfile : Profile
    {
        public AuthorizedPersonProfile()
        {
            CreateMap<AuthorizedPersonWithoutLists, AuthorizedPerson>();
            CreateMap<AuthorizedPersonCreation, AuthorizedPerson>();
            CreateMap<AuthorizedPerson, AuthorizedPersonDto>();
        }
    }
}
