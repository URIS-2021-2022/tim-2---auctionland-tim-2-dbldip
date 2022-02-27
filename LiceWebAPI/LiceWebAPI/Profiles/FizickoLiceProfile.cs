using AutoMapper;
using LiceWebAPI.Entities;
using LiceWebAPI.Models.Lice.FizickoLice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Profiles
{
    public class FizickoLiceProfile : Profile
    {
        public FizickoLiceProfile() 
        {
            CreateMap<FizickoLice, FizickoLiceCreateDto>().ReverseMap();
            CreateMap<FizickoLiceUpdateDto, FizickoLice>();
            CreateMap<FizickoLice, FizickoLice>();
            CreateMap<FizickoLice, FizickoLiceDto>();
        }
            
    }
}
