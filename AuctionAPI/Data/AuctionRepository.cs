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
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public AuctionWithoutLists GetAuctionById(Guid auctionId)
        {
            return context.Auctions.FirstOrDefault(a => a.auctionId == auctionId);
        }


        public AuctionConfirmation CreateAuction(Auction auction)
        {
            var createdEntity = context.Add(auction);
            return mapper.Map<AuctionConfirmation>(createdEntity.Entity);
        }

        public List<AuctionWithoutLists> GetAuctions()
        {
            return context.Auctions.ToList();
        }

        public void CreateAuction(CreationAuctionDto auctionCreation)
        {
            var createdEntity = context.Add(auctionCreation);
            //return mapper.Map<AuctionConfirmation>(createdEntity.Entity);

        }

        public AuctionWithoutLists GetAuctionByNumber(int auctionNumber)
        {
            return context.Auctions.FirstOrDefault(a => a.auctionNumber == auctionNumber);
        }

        public void UpdateAuction(CreationAuctionDto auctionCreation)
        {
            //Nije potrebna implementacija jer EF core prati entitet koji smo izvukli iz baze
            //i kada promenimo taj objekat i odradimo SaveChanges sve izmene će biti perzistirane
        }

        public void DeleteAuction(Guid auctionId)
        {
            var creation = GetAuctionById(auctionId);
            context.Remove(creation);
        }
    }
}
