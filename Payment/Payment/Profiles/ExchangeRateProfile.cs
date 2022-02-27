using AutoMapper;
using PaymentService.Entities;
using PaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Profiles
{
    public class ExchangeRateProfile : Profile
    {
        public ExchangeRateProfile()
        {
            CreateMap<ExchangeRate, ExchangeRateDto>();
            CreateMap<ExchangeRateCreationDto, ExchangeRate>();
            CreateMap<ExchangeRateUpdateDto, ExchangeRate>();
            CreateMap<ExchangeRate, ExchangeRate>();

        }
    }
}
