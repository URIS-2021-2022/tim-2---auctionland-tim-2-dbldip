using AuctionAPI.Entities;
using AuctionAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Data
{

    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionContext context;
        private readonly IMapper mapper;

        public AuctionRepository(AuctionContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public static List<AuctionDto> AuctionCreations { get; set; } = new List<AuctionDto>();

        
    }
}
