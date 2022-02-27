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
    /// Maper za klasu kreiranja licitacije
    /// </summary>
    public class AuctionCreateProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje licitacije
        /// </summary>
        public AuctionCreateProfile()
        {

            CreateMap<AuctionConfirmation, AuctionConfirmationDto>();
        }
    }
}
