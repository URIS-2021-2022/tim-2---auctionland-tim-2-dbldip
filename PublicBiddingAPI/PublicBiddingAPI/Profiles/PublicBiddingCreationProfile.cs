using AutoMapper;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Profiles
{
    public class PublicBiddingCreationProfile : Profile
    {
        public PublicBiddingCreationProfile()
        {
            CreateMap<PublicBiddingCreationDto, PublicBiddingCreation>();
        }
    }
}
