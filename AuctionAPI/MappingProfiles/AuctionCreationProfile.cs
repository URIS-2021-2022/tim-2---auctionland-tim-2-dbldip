using AuctionAPI.Entities;
using AuctionAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.MappingProfiles
{
    public class AuctionCreationProfile : Profile
    {
        public AuctionCreationProfile()
        {
            CreateMap<AuctionCreation, AuctionCreationDto>();

            CreateMap<AuctionCreationDto, CreationDto>();
        }
    }
}
