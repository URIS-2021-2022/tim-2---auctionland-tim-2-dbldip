using AutoMapper;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Profiles
{
    public class TypeOfPublicBiddingProfile : Profile
    {
        public TypeOfPublicBiddingProfile()
        {
            CreateMap<TypeOfPublicBidding, TypeOfPublicBiddingDto>();
        }
    }
}
