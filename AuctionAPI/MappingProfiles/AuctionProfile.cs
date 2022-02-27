using AuctionAPI.Entities;
using AuctionAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.MappingProfiles
{
    /// <summary>
    /// Maper za klasu licitacije
    /// </summary>
    public class AuctionProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje licitacije
        /// </summary>
        public AuctionProfile()
        {
            CreateMap<Auction, AuctionDto>();

            CreateMap<AuctionConfirmation, AuctionConfirmationDto>();

            CreateMap<Auction, AuctionConfirmation>();

            CreateMap<AuctionDto, CreationAuctionDto>();

        }
    }
}
