using AutoMapper;
using Projekat.Entities;
using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Profiles
{
    public class PersonConfirmationProfile : Profile
    {
        public PersonConfirmationProfile()
        {
            CreateMap<PersonConfirmation, PersonConfirmationDto>();
            CreateMap<Person, PersonConfirmationDto>();

        }
    }
}
