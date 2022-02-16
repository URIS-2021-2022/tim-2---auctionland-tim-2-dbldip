using AutoMapper;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Profiles
{
    public class PublicBiddingProfile : Profile
    {
        public PublicBiddingProfile()
        {
            CreateMap<PublicBiddingWithoutListsProfile, PublicBidding>();
            CreateMap<PublicBiddingCreation, PublicBidding>();
            CreateMap<PublicBidding, PublicBiddingDto>();
        }
    }
}
