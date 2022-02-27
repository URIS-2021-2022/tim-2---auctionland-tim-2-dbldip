using AutoMapper;
using AuctionAPI.Entities;
using AuctionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.MappingProfiles
{
    /// <summary>
    /// Maper za klasu izmene licitacije
    /// </summary>
    public class AuctionUpdateProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje izmene licitacije
        /// </summary>
        public AuctionUpdateProfile() 
        { 
            CreateMap<AuctionUpdateDto, AuctionWithoutLists>();
        }
    }
}
