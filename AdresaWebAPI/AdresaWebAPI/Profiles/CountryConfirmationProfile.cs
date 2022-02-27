using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Profiles
{
    public class CountryConfirmationProfile : Profile
    {
        public CountryConfirmationProfile()
        {
            CreateMap<CountryConfirmation, CountryConfirmationDto>();
            CreateMap<Country, CountryConfirmation>();
        }
    }
}
