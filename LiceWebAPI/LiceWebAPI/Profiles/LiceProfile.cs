using AutoMapper;
using LiceWebAPI.Entities;
using LiceWebAPI.Models.Lice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Profiles
{
    public class LiceProfile : Profile
    {
        public LiceProfile()
        {
            CreateMap<FizickoLice, LiceDto>()
                .ForMember(
                dest => dest.Naziv,
                opt => opt.MapFrom(src => src.Ime + " " + src.Prezime))
                .ForMember(
                dest => dest.KontaktOsoba,
                opt => opt.Ignore())
                .ForMember(
                dest => dest.Faks,
                opt => opt.Ignore())
                  .ForMember(
                dest => dest.Maticnibroj,
                opt => opt.Ignore());
                

            CreateMap<PravnoLice, LiceDto>()
                  .ForMember(
                dest => dest.Jmbg,
                opt => opt.Ignore());

        }
    }
}
