using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class BuyerConfirmationProfile : Profile
    {
        public BuyerConfirmationProfile()
        {
            CreateMap<BuyerCreation, BuyerConfirmation>();
            CreateMap<BuyerConfirmation, BuyerConfirmationDto>();
            CreateMap<Buyer, BuyerConfirmation>();
            CreateMap<BuyerWithoutLists, BuyerConfirmation>();
        }
    }
}
