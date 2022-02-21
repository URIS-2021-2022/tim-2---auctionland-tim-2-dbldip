﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Profiles
{
    public class GuaranteeTypeConfirmationProfile : Profile
    {
        public GuaranteeTypeConfirmationProfile()
        {
            CreateMap<GuaranteeType, GuaranteeTypeConfirmation>();
            CreateMap<GuaranteeTypeConfirmation, GuaranteeTypeConfirmationDto>();
        }
    }
}
