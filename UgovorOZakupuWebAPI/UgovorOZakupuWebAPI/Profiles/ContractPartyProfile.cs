using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Profiles
{
    public class ContractPartyProfile : Profile
    {
        public ContractPartyProfile()
        {
            CreateMap<ContractParty, ContractPartyDto>();
            CreateMap<ContractPartyDto, ContractParty>();
            CreateMap<ContractParty, ContractParty>();
            CreateMap<ContractParty, ContractPartyConfirmation>();
        }
    }
}
