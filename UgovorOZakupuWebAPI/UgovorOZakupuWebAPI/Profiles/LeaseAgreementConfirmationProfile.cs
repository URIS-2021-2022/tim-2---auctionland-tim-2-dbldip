using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Profiles
{
    public class LeaseAgreementConfirmationProfile : Profile
    {
        public LeaseAgreementConfirmationProfile()
        {
            CreateMap<LeaseAgreement, LeaseAgreementConfirmation>();
            CreateMap<LeaseAgreementDto, LeaseAgreementConfirmation>();
            CreateMap<LeaseAgreementConfirmation, LeaseAgreementConfirmationDto>();
        }
    }
}
