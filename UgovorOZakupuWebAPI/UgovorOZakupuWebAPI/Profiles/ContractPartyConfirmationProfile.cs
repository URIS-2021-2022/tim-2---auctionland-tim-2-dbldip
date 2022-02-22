using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Profiles
{
    public class ContractPartyConfirmationProfile : Profile
    {
        public ContractPartyConfirmationProfile()
        {
            CreateMap<ContractPartyConfirmation, ContractPartyConfirmationDto>();
        }
    }
}
