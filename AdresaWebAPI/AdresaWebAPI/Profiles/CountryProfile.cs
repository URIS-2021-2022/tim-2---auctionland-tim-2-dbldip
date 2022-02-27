using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryCreationDto, Country>();
            CreateMap<CountryDto, Country>();
            CreateMap<Country, Country>();
        }
    }
}
