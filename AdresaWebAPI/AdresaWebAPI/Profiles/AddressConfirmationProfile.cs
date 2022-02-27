using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Profiles
{
    public class AddressConfirmationProfile : Profile
    {
        public AddressConfirmationProfile()
        {
            CreateMap<AddressConfirmation, AddressConfirmationDto>();
            CreateMap<Address, AddressConfirmation>();
        }
    }
}
