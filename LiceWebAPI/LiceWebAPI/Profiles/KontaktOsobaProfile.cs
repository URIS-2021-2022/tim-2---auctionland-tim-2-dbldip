using AutoMapper;
using LiceWebAPI.Entities;
using LiceWebAPI.Models.KontaktOsoba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Profiles
{
    public class KontaktOsobaProfile : Profile
    {
        public KontaktOsobaProfile()
        {
            CreateMap<KontaktOsoba, KontaktOsobaCreateDto>().ReverseMap();
            CreateMap<KontaktOsobaUpdateDto, KontaktOsoba>();
            CreateMap<KontaktOsoba, KontaktOsoba>();
            CreateMap<KontaktOsoba, KontaktOsobaDto>();
        }
    }
}
