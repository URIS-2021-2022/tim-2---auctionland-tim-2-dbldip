using AutoMapper;
using OglasWebAPI.Entities;
using OglasWebAPI.Models.Oglas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Profiles
{
    public class OglasProfile : Profile
    {
        public OglasProfile()
        {
            CreateMap<Oglas, OglasCreateDto>().ReverseMap();
            CreateMap<OglasUpdateDto, Oglas>();
            CreateMap<Oglas, Oglas>();
            CreateMap<Oglas, OglasDto>();
        }
    }
}
