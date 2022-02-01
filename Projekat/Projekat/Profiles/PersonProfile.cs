using AutoMapper;
using Projekat.Entities;
using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Person, PersonCreationDto>();
            CreateMap<PersonCreationDto, Person>();
            CreateMap<PersonUpdateDto, Person>();
        }
    }
}
