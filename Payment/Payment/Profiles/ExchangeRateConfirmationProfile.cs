using AutoMapper;
using PaymentService.Entities;
using PaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Profiles
{
    public class ExchangeRateConfirmationProfile : Profile
    {
        public ExchangeRateConfirmationProfile()
        {
            CreateMap<ExchangeRateConfirmation, ExchangeRateConfirmationDto>();
            CreateMap<ExchangeRate, ExchangeRateConfirmation>();
        }
    }
}
