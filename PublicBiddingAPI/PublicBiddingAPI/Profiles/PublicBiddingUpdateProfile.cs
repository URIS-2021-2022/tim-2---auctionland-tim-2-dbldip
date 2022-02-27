using AutoMapper;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Profiles
{
    public class PublicBiddingUpdateProfile : Profile
    {
        public PublicBiddingUpdateProfile()
        {
            CreateMap<PublicBiddingUpdateDto, PublicBiddingUpdate>();
            CreateMap<PublicBiddingUpdateDto, PublicBiddingWithoutLists>();

        }
    }
}
