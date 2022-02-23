using AutoMapper;
using AuctionAPI.Entities;
using AuctionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.MappingProfiles
{
    public class AuctionUpdateProfile : Profile
    {
        public AuctionUpdateProfile() 
        { 
            CreateMap<AuctionUpdate, AuctionWithoutLists>();
        }
    }
}
