using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Profiles
{
    public class LeaseAgreementProfile : Profile
    {
        public LeaseAgreementProfile()
        {
            CreateMap<LeaseAgreementCreation, LeaseAgreement>();
            CreateMap<LeaseAgreementCreationDto, LeaseAgreementCreation>();
            CreateMap<LeaseAgreementWithLists, LeaseAgreementDto>();
            CreateMap<LeaseAgreementWithLists, LeaseAgreement>();
            CreateMap<LeaseAgreement, LeaseAgreementWithLists>();
            CreateMap<LeaseAgreement, LeaseAgreementDto>();
            CreateMap<LeaseAgreementDto, LeaseAgreement>();
            CreateMap<LeaseAgreementDto, LeaseAgreementCreation>();
            CreateMap<LeaseAgreementUpdateDto, LeaseAgreement>();
        }
    }
}
