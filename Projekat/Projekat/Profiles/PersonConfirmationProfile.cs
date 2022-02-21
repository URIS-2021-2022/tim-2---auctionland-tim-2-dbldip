using AutoMapper;
using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Profiles
{
    public class PersonConfirmationProfile : Profile
    {
        public PersonConfirmationProfile()
        {
            CreateMap<PersonConfirmation, PersonConfirmationDto>();
            CreateMap<Person, PersonConfirmation>();

        }
    }
}
