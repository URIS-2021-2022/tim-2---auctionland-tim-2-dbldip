using AuctionAPI.Entities;
using AuctionAPI.Entities.ManyToMany;
using AuctionAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Data
{
    /// <summary>
    /// Repozitorijum licitacije
    /// </summary>
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Konstruktor repozitorijuma licitacije
        /// </summary>
        /// <param name="context">Db Context</param>
        /// <param name="mapper">AutoMapper</param>
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
            var auction = context.Auctions.FirstOrDefault(a => a.auctionId == auctionId);

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
        /// <param name="auction">Objekat licitacije</param>
        /// <returns>Potvrdu kreirane licitacije</returns>
        public AuctionConfirmation CreateAuction(CreationAuctionDto auctionCreation)
        {
            var mappedEntity = mapper.Map<AuctionWithoutLists>(auctionCreation);
            var createdEntity = context.Add(mappedEntity);


            foreach(var pubBid in auctionCreation.publicBiddingIds)
            {
                var tempAPB = new AuctionPublicBidding();
                tempAPB.publicBiddingId = pubBid;
                tempAPB.auctionId = createdEntity.Entity.auctionId;
                context.AuctionPublicBidding.Add(tempAPB);
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
                return new List<Auction>();

            List<Auction> returnList = mapper.Map<List<Auction>>(auctions);
            foreach(var auc in returnList)
            {
                auc.publicBiddings = context.AuctionPublicBidding
                    .Where(apb => apb.auctionId == auc.auctionId)
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
        public void UpdateAuction(AuctionUpdateDto auction)
        {
            var auctionToUpdate = context.Auctions.FirstOrDefault(auc => auc.auctionId == auction.auctionId);

            var publicBiddings = context.AuctionPublicBidding
                .Where(pb => pb.auctionId == auction.auctionId)
                .ToList();

            context.AuctionPublicBidding.RemoveRange(publicBiddings);

            foreach(var pb in auction.publicBiddingIds)
            {
                var tempAPB = new AuctionPublicBidding();
                tempAPB.auctionId = auction.auctionId;
                tempAPB.publicBiddingId = pb;
                context.AuctionPublicBidding.Add(tempAPB);
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
            
            context.Remove(auction);

            /* prethodna verzija, nije potrebno zbog kaskadnog brisanja podešenog u AuctionContext
            var publicBiddingsToDelete = context.AuctionPublicBidding
                .Where(pb => pb.auctionId == auction.auctionId)
                .ToList();

            context.RemoveRange(publicBiddingsToDelete);
            */
        }

        /// <summary>
        /// Čuvanje promena u bazu
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
