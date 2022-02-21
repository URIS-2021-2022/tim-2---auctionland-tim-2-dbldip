using AutoMapper;
using KupacWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class AuthorizedPersonWithoutListsProfile : Profile
    {
        public AuthorizedPersonWithoutListsProfile()
        {
            CreateMap<AuthorizedPersonCreation, AuthorizedPersonWithoutLists>();
        }
    }
}
