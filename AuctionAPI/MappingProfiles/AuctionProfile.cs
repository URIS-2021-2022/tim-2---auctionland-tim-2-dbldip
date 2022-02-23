using AuctionAPI.Entities;
using AuctionAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.MappingProfiles
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<Auction, AuctionDto>();

            CreateMap<AuctionConfirmation, AuctionConfirmationDto>();

            CreateMap<Auction, AuctionConfirmation>();

            CreateMap<AuctionDto, CreationAuctionDto>();

        }
    }
}
