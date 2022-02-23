using AuctionAPI.Entities;
using AuctionAPI.Entities.ConnectionClasses;
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

        /// <summary>
        /// Prikaz licitacije na osnovu unetog ID-ja
        /// </summary>
        /// <param name="auctionId">ID licitacije</param>
        /// <returns>Licitaciju sa unetim ID-jem</returns>
        public Auction GetAuctionById(Guid auctionId)
        {
            var auction = this.context.Auctions.FirstOrDefault(a => a.auctionId == auctionId);
            if (auction == null)
            {
                return null;
            }
            var returnAuction = mapper.Map<Auction>(auction);
            returnAuction.publicBiddings = context.AuctionPublicBidding
                .Where(pb => pb.auctionId == auction.auctionId)
                .ToList();
            return returnAuction;
        }

        /// <summary>
        /// Kreiranje licitacije
        /// </summary>
        /// <param name="auction"></param>
        /// <returns>Potvrdu kreirane licitacije</returns>
        public AuctionConfirmation CreateAuction(CreationAuctionDto auction)
        {
            var mappedEntity = mapper.Map<AuctionWithoutLists>(auction);
            var createdEntity = context.Add(mappedEntity);

            foreach(var pubBid in auction.publicBiddingIds)
            {
                var temp = new AuctionPublicBiddingConnection();
                temp.publicBiddingId = pubBid;
                temp.auctionId = createdEntity.Entity.auctionId;
                context.Add(temp);
            }

            return mapper.Map<AuctionConfirmation>(createdEntity.Entity);
        }

        /// <summary>
        /// Prikazivanje svih licitacija
        /// </summary>
        /// <returns>Lista svih licitacija</returns>
        public List<Auction> GetAuctions()
        {
            var auctions = this.context.Auctions.ToList();
            if (auctions == null || auctions.Count == 0)
                return null;

            List<Auction> returnList = mapper.Map<List<Auction>>(auctions);
            foreach(var auc in auctions)
            {
                context.AuctionPublicBidding
                    .Where(apb => apb.auctionId == auc.auctionId)
                    .Select(pb => pb.publicBiddingId)
                    .ToList();
            }
            return returnList;
        }

   
        /// <summary>
        /// Prikaz licitacije na osnovu unetog broja licitacije
        /// </summary>
        /// <param name="auctionNumber">Broj licitacije</param>
        /// <returns>Licitaciju sa unetim brojem</returns>
        public Auction GetAuctionByNumber(int auctionNumber)
        {
            var auction = this.context.Auctions.FirstOrDefault(a => a.auctionNumber == auctionNumber);
            
            if (auction == null)
            {
                return null;
            }

            var returnAuction = mapper.Map<Auction>(auction);
            returnAuction.publicBiddings = context.AuctionPublicBidding
                .Where(pb => pb.auctionId == auction.auctionId)
                .ToList();

            return returnAuction;
        }

        /// <summary>
        /// Izmena licitacije
        /// </summary>
        /// <param name="auctionCreation">Izmenjena licitacija</param>
        public void UpdateAuction(AuctionUpdate auction)
        {
            var auctionToUpdate = context.Auctions.FirstOrDefault(auc => auc.auctionId == auction.auctionId);

            var publicBiddings = context.AuctionPublicBidding
                .Where(pb => pb.auctionId == auction.auctionId)
                .ToList();

            context.RemoveRange(publicBiddings);

            foreach(var pb in auction.publicBiddingIds)
            {
                var temp = new AuctionPublicBiddingConnection();
                temp.auctionId = auction.auctionId;
                temp.publicBiddingId = pb;
                context.Add(temp);
            }

            var newValues = mapper.Map<AuctionWithoutLists>(auction);
            mapper.Map(newValues, auctionToUpdate);
        }


        /// <summary>
        /// Brisanje licitacije sa prosledjenim ID-jem
        /// </summary>
        /// <param name="auctionId">ID licitacije za brisanje</param>
        public void DeleteAuction(Guid auctionId)
        {
            var auction = GetAuctionById(auctionId);

            var publicBiddingsToDelete = context.AuctionPublicBidding
                .Where(pb => pb.auctionId == auction.auctionId)
                .ToList();

            context.RemoveRange(publicBiddingsToDelete);
            context.Remove(auction);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
