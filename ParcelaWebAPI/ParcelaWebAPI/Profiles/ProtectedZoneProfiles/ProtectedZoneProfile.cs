using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.ProtectedZoneDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.ProtectedZoneProfiles
{
    public class ProtectedZoneProfile : Profile
    {
        public ProtectedZoneProfile()
        {
            CreateMap<ProtectedZone, ProtectedZoneDto>();
            CreateMap<ProtectedZoneDto, ProtectedZone>();
            CreateMap<ProtectedZone, ProtectedZone>();
        }
    }
}
