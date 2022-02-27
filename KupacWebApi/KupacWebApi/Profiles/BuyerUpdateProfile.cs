using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class BuyerUpdateProfile : Profile
    {
        public BuyerUpdateProfile()
        {
            CreateMap<BuyerUpdateDto, BuyerUpdate>();
            CreateMap<BuyerUpdateDto, BuyerWithoutLists>();

        }
    }
}
