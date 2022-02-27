using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>()
                .ForMember(
                    dest => dest.completeAddress,
                    opt => opt.MapFrom(src => $"{src.addressStreet} {src.addressNumber}"))
                .ForMember(
                    dest => dest.townInfo,
                    opt => opt.MapFrom(src => $"{src.addressTown}, {src.addressMunicipality}, {src.addressPostalCode}"))
                .ForMember(
                    dest => dest.country,
                    opt => opt.MapFrom(src => $"{src.countryName}"));
            CreateMap<AddressCreationDto, Address>();
            CreateMap<AddressUpdateDto, Address>();
            CreateMap<Address, Address>();
        }
    }
}
