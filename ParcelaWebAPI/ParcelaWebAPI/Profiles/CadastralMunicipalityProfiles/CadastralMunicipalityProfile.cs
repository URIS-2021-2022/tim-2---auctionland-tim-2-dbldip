using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.CadastralMunicipalityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.CadastralMunicipalityProfiles
{
    public class CadastralMunicipalityProfile : Profile
    {
        public CadastralMunicipalityProfile()
        {
            CreateMap<CadastralMunicipality, CadastralMunicipalityDto>();
            CreateMap<CadastralMunicipalityDto, CadastralMunicipality>();
            CreateMap<CadastralMunicipality, CadastralMunicipality>();
        }
    }
}
