using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class BuyerProfile : Profile
    {
        public BuyerProfile()
        {
            CreateMap<BuyerWithoutLists, Buyer>();
            CreateMap<BuyerCreation, Buyer>();
            CreateMap<Buyer, BuyerDto>();
        }
        
    }
}
