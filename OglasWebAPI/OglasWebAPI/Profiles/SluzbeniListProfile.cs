using AutoMapper;
using OglasWebAPI.Entities;
using OglasWebAPI.Models.SluzbeniList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Profiles
{
    public class SluzbeniListProfile : Profile
    {
        public SluzbeniListProfile()
        {
            CreateMap<SluzbeniList, SluzbeniListCreateDto>().ReverseMap();
            CreateMap<SluzbeniListUpdateDto, SluzbeniList>();
            CreateMap<SluzbeniList, SluzbeniList>();
            CreateMap<SluzbeniList, SluzbeniListDto>();
        }
    }
}
