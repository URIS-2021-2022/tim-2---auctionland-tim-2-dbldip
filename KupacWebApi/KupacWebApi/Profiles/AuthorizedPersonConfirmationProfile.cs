using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class AuthorizedPersonConfirmationProfile : Profile
    {
        public AuthorizedPersonConfirmationProfile()
        {
            CreateMap<AuthorizedPersonCreation, AuthorizedPersonConfirmation>();
            CreateMap<AuthorizedPersonConfirmation, AuthorizedPersonConfirmationDto>();
            CreateMap<AuthorizedPerson, AuthorizedPersonConfirmation>();
            CreateMap<AuthorizedPersonWithoutLists, AuthorizedPersonConfirmation>();
        }
        
    }
}
