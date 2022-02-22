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
        public Auction GetAuctionById(Guid auctionId)
        {
            return context.Auctions.FirstOrDefault(a => a.AuctionId == auctionId);
        }


        public AuctionConfirmation CreateAuction(Auction auction)
        {
            var createdEntity = context.Add(auction);
            return mapper.Map<AuctionConfirmation>(createdEntity.Entity);
        }

        public List<Auction> GetAuctions()
        {
            return context.Auctions.ToList();
        }

        public Auction CreateAuction(CreationAuctionDto auctionCreation)
        {
            throw new NotImplementedException();
        }

        public Auction GetAuctionByNumber(int auctionNumber)
        {
            return context.Auctions.FirstOrDefault(a => a.AuctionNumber == auctionNumber);
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
