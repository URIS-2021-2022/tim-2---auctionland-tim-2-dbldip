using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class BuyerCreationProfile : Profile
    {
        public BuyerCreationProfile()
        {
            CreateMap<BuyerCreationDto, BuyerCreation>();
        }
    }
}
