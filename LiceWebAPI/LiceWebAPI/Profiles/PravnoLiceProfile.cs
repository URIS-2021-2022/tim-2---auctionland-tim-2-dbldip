using AutoMapper;
using LiceWebAPI.Entities;
using LiceWebAPI.Models.Lice.PravnoLice;
using LiceWebAPI.Models.PravnoLice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Profiles
{
    public class PravnoLiceProfile : Profile
    {
        public PravnoLiceProfile()
        {
            CreateMap<PravnoLice, PravnoLiceCreateDto>().ReverseMap();
            CreateMap<PravnoLiceUpdateDto, PravnoLice>();
            CreateMap<PravnoLice, PravnoLice>();
            CreateMap<PravnoLice, PravnoLiceDto>();
        }
    }
}
