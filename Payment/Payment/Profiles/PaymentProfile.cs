using AutoMapper;
using PaymentService.Entities;
using PaymentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentCreationDto, Payment>();
            CreateMap<PaymentUpdateDto, Payment>();
            CreateMap<Payment, Payment>();
        }
    }
}
