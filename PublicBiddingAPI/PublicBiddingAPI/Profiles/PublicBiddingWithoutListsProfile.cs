using AutoMapper;
using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Profiles
{
    public class PublicBiddingWithoutListsProfile : Profile
    {
        public PublicBiddingWithoutListsProfile()
        {
            CreateMap<PublicBiddingCreation, PublicBiddingWithoutLists>();
        }
    }
}
