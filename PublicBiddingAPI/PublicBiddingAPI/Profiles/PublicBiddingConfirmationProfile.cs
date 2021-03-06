using AutoMapper;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Profiles
{
    public class PublicBiddingConfirmationProfile : Profile
    {
        public PublicBiddingConfirmationProfile()
        {
            CreateMap<PublicBiddingCreation, PublicBiddingConfirmation>();
            CreateMap<PublicBiddingConfirmation, PublicBiddingConfirmationDto>();
            CreateMap<PublicBidding, PublicBiddingConfirmation>();
            CreateMap<PublicBiddingWithoutLists, PublicBiddingConfirmation>();
        }
    }
}
