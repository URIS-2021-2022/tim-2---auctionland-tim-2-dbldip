using AutoMapper;
using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Person, Person>();
            CreateMap<PersonUpdateDto, Person>();
            CreateMap<PersonDto, Person>();
            CreateMap<PersonCreationDto, Person>();
        }
    }
}
