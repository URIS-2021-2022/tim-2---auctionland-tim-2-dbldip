using AutoMapper;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicBiddingAPI.Data
{
    public class PublicBiddingRepository : IPublicBiddingRepository
    {
        private readonly PublicBiddingContext context;
        private readonly IMapper mapper;

        public PublicBiddingRepository(PublicBiddingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public PublicBiddingConfirmation createPublicBidding(PublicBiddingCreation publicBidding)
        {
            var mappedEntity = mapper.Map<PublicBiddingWithoutLists>(publicBidding);
            var createdEntity = context.Add(mappedEntity);            
            foreach (var el in publicBidding.appliedBuyersId)
            {
                var temp = new Buyer();
                temp.buyerId = el;
                temp.publicBiddingId = createdEntity.Entity.publicBiddingId;
                context.Add(temp);
            }
            foreach(var el in publicBidding.biddersId)
            {
                var temp = new Bidder();
                temp.bidderId = el;
                temp.publicBiddingId = createdEntity.Entity.publicBiddingId;
                context.Add(temp);
            }
            foreach(var el in publicBidding.plotIds)
            {
                var temp = new Plot();
                temp.plotId = el;
                temp.publicBiddingId = createdEntity.Entity.publicBiddingId;
                context.Add(temp);
            }
            var bestBidder = new BestBidder();
            bestBidder.bestBidderId = publicBidding.bestBidderId;
            bestBidder.publicBiddingId = createdEntity.Entity.publicBiddingId;
            context.Add(bestBidder);

            return mapper.Map<PublicBiddingConfirmation>(createdEntity.Entity);
        }

        public void DeletePublicBidding(Guid publicBiddingId)
        {
            //NOT IMPLEMENTED YET
        }

        public List<PublicBidding> getAllPublicBiddings()
        {            
            var biddings = this.context.PublicBiddings.ToList();
            if (biddings == null || biddings.Count == 0)
                return null;
            List<PublicBidding> returnList = mapper.Map<List<PublicBidding>>(biddings);
            foreach (var el in returnList)
            {
                el.appliedBuyers = context.AppliedBuyers.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidders.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                el.bidders = context.Bidders.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plots.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
            }
            return returnList;
            //ODRADIM GET IZ TABELE ZA SVAKI OD PAROVA POSEBNO I DODAM U OBJEKAT PA VRATIM
            //return context.PublicBiddings.ToList();
        }

        public PublicBidding getPublicBidding(Guid biddingId)
        {
            //GETTING THE PUBLIC BIDDING WITH PUBLICBIDDINGID PASSED AS A PARAMETER 
            var bidding = this.context.PublicBiddings.FirstOrDefault(e => e.publicBiddingId == biddingId);
            //CHECKING TO SEE IF THERE IS A PUBLIC BIDDING WITH SPECIFIED ID
            if (bidding == null)
                return null;
            //IF THERE ISNT A PUBLIC BIDDING WITH THAT ID, THERES NO POINT IN CALLING MAPPER OR GETTING OTHER DATA
            var returnBidding = mapper.Map<PublicBidding>(bidding);
            //FILLING THE LISTS WITH DATA FROM OTHER TABLES
            returnBidding.appliedBuyers = context.AppliedBuyers.Where(e => e.publicBiddingId == bidding.publicBiddingId).ToList();
            returnBidding.bestBidder = context.BestBidders.FirstOrDefault(e => e.publicBiddingId == bidding.publicBiddingId);
            returnBidding.bidders = context.Bidders.Where(e => e.publicBiddingId == bidding.publicBiddingId).ToList();
            returnBidding.plots = context.Plots.Where(e => e.publicBiddingId == bidding.publicBiddingId).ToList();
            return returnBidding;

        }

        public List<PublicBidding> getPublicBiddingsByAppliedBuyer(Guid buyerId)
        {
            var biddings = this.context.PublicBiddings.ToList();
            if (biddings == null || biddings.Count == 0)
                return null;
            List<PublicBidding> tempList = mapper.Map<List<PublicBidding>>(biddings);
            List<PublicBidding> returnList = new List<PublicBidding>();
            foreach (var el in tempList)
            {
                el.appliedBuyers = context.AppliedBuyers.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bidders = context.Bidders.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plots.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidders.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                foreach (var temp in el.appliedBuyers)
                {
                    if (temp.buyerId == buyerId)
                    {
                        returnList.Add(el);
                        break;
                    }
                }
            }

            return returnList;

        }

        public List<PublicBidding> getPublicBiddingsByBestBidder(Guid bestBidderId)
        {
            throw new NotImplementedException();
            //return context.PublicBiddings.Where(e => e.buyerId == bestBidderId).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByBidder(Guid bidderId)
        {
            throw new NotImplementedException();
            //return context.PublicBiddings.Where(e => e.biddersIds.Contains(bidderId)).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByCadastralMunicipality(Guid cadastralMunicipalityId)
        {
            throw new NotImplementedException();
            //return context.PublicBiddings.Where(e => e.cadastralMunicipality.cadastralMuniciplaityId == cadastralMunicipalityId).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByLeasePeriod(double period)
        {
            throw new NotImplementedException();
            //return context.PublicBiddings.Where(e => e.leasePeriod == period).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByStartingPricePerHectare(double price)
        {
            throw new NotImplementedException();
            //return context.PublicBiddings.Where(e => e.startingPricePerHectare == price).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByType(Guid typeOfPublicBidding)
        {
            throw new NotImplementedException();
            //return context.PublicBiddings.Where(e => e.typeOfPublicBidding.typeOfPublicBiddingId == typeOfPublicBidding).ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdatePublicBidding(PublicBidding publicBidding)
        {

        }
    }
}
