using AutoMapper;
using ParcelaWebAPI.Entities;
using ParcelaWebAPI.Models.CadastralMunicipalityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Profiles.CadastralMunicipalityProfiles
{
    public class CadastralMunicipalityConfirmationProfile : Profile
    {
        public CadastralMunicipalityConfirmationProfile()
        {
            CreateMap<CadastralMunicipalityConfirmation, CadastralMunicipalityConfirmationDto>();
            CreateMap<CadastralMunicipality, CadastralMunicipalityConfirmation>();
        }
        
    }
}
