using AutoMapper;
using KupacWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Profiles
{
    public class BuyerWithoutListsProfile : Profile
    {
        public BuyerWithoutListsProfile()
        {
            CreateMap<BuyerCreation, BuyerWithoutLists>();
        }
    }
}
