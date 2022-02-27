using AutoMapper;
using PublicBiddingAPI.Entities;
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

        //
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
            var publicBiddingToDelete = context.PublicBidding.FirstOrDefault(e => e.publicBiddingId == publicBiddingId);
            var listOfbidders = this.context.Bidder.Where(e => e.publicBiddingId == publicBiddingId).ToList();
            var listOfAppliedBuyers = this.context.AppliedBuyer.Where(e => e.publicBiddingId == publicBiddingId).ToList();
            var listOfPlots = this.context.Plot.Where(e => e.publicBiddingId == publicBiddingId).ToList();
            var bestBidder = this.context.BestBidder.FirstOrDefault(e => e.publicBiddingId == publicBiddingId);

            context.RemoveRange(listOfbidders);
            context.RemoveRange(listOfAppliedBuyers);
            context.RemoveRange(listOfPlots);
            context.Remove(bestBidder);
            context.Remove(publicBiddingToDelete);

        }

        public List<PublicBidding> getAllPublicBiddings()
        {            
            var biddings = this.context.PublicBidding.ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> returnList = mapper.Map<List<PublicBidding>>(biddings);
            foreach (var el in returnList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
            }
            return returnList;
        }

        public PublicBidding getPublicBidding(Guid biddingId)
        {
            //GETTING THE PUBLIC BIDDING WITH PUBLICBIDDINGID PASSED AS A PARAMETER 
            var bidding = this.context.PublicBidding.FirstOrDefault(e => e.publicBiddingId == biddingId);
            //CHECKING TO SEE IF THERE IS A PUBLIC BIDDING WITH SPECIFIED ID
            if (bidding == null)
                return null;
            //IF THERE ISNT A PUBLIC BIDDING WITH THAT ID, THERES NO POINT IN CALLING MAPPER OR GETTING OTHER DATA
            var returnBidding = mapper.Map<PublicBidding>(bidding);
            //FILLING THE LISTS WITH DATA FROM OTHER TABLES
            returnBidding.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == bidding.publicBiddingId).ToList();
            returnBidding.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == bidding.publicBiddingId);
            returnBidding.bidders = context.Bidder.Where(e => e.publicBiddingId == bidding.publicBiddingId).ToList();
            returnBidding.plots = context.Plot.Where(e => e.publicBiddingId == bidding.publicBiddingId).ToList();
            return returnBidding;

        }

        public List<PublicBidding> getPublicBiddingsByAppliedBuyer(Guid buyerId)
        {
            var biddings = this.context.PublicBidding.ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> tempList = mapper.Map<List<PublicBidding>>(biddings);
            List<PublicBidding> returnList = new List<PublicBidding>();
            foreach (var el in tempList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
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
            var biddings = this.context.PublicBidding.ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> tempList = mapper.Map<List<PublicBidding>>(biddings);
            List<PublicBidding> returnList = new List<PublicBidding>();
            foreach (var el in tempList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                if (el.bestBidder.bestBidderId == bestBidderId)
                {
                    returnList.Add(el);
                }
            }

            return returnList;
        }

        public List<PublicBidding> getPublicBiddingsByBidder(Guid bidderId)
        {
            var biddings = this.context.PublicBidding.ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> tempList = mapper.Map<List<PublicBidding>>(biddings);
            List<PublicBidding> returnList = new List<PublicBidding>();
            foreach (var el in tempList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                foreach (var temp in el.bidders)
                {
                    if (temp.bidderId == bidderId)
                    {
                        returnList.Add(el);
                        break;
                    }
                }
            }

            return returnList;
        }

        public List<PublicBidding> getPublicBiddingsByCadastralMunicipality(Guid cadastralMunicipalityId)
        {
            var biddings = this.context.PublicBidding.Where(e => e.cadastralMunicipality.cadastralMuniciplaityId == cadastralMunicipalityId).ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> returnList = mapper.Map<List<PublicBidding>>(biddings);
            foreach (var el in returnList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
            }
            return returnList;
        }

        public List<PublicBidding> getPublicBiddingsByLeasePeriod(double period)
        {
            var biddings = this.context.PublicBidding.Where(e => e.leasePeriod == period).ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> returnList = mapper.Map<List<PublicBidding>>(biddings);
            foreach (var el in returnList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
            }
            return returnList;
        }

        public List<PublicBidding> getPublicBiddingsByStartingPricePerHectare(double price)
        {
            var biddings = this.context.PublicBidding.Where(e=>e.startingPricePerHectare == price).ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> returnList = mapper.Map<List<PublicBidding>>(biddings);
            foreach (var el in returnList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
            }
            return returnList;
        }

        public List<PublicBidding> getPublicBiddingsByType(Guid typeOfPublicBidding)
        {
            var biddings = this.context.PublicBidding.Where(e=>e.typeOfPublicBidding.typeOfPublicBiddingId == typeOfPublicBidding).ToList();
            if (biddings == null || biddings.Count == 0)
                return new List<PublicBidding>();
            List<PublicBidding> returnList = mapper.Map<List<PublicBidding>>(biddings);
            foreach (var el in returnList)
            {
                el.appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == el.publicBiddingId);
                el.bidders = context.Bidder.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
                el.plots = context.Plot.Where(e => e.publicBiddingId == el.publicBiddingId).ToList();
            }
            return returnList;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdatePublicBidding(PublicBiddingUpdate publicBidding)
        {
            //var publicBiddingToUpdate = getPublicBidding(publicBidding.publicBiddingId);
            var publicBiddingToUpdate = context.PublicBidding.FirstOrDefault(e => e.publicBiddingId == publicBidding.publicBiddingId);

            var appliedBuyers = context.AppliedBuyer.Where(e => e.publicBiddingId == publicBidding.publicBiddingId).ToList();
            var bestBidder = context.BestBidder.FirstOrDefault(e => e.publicBiddingId == publicBidding.publicBiddingId);
            var bidders = context.Bidder.Where(e => e.publicBiddingId == publicBidding.publicBiddingId).ToList();
            var plots = context.Plot.Where(e => e.publicBiddingId == publicBidding.publicBiddingId).ToList();

            context.RemoveRange(bidders);
            context.RemoveRange(appliedBuyers);
            context.RemoveRange(plots);
            context.Remove(bestBidder);

            foreach (var el in publicBidding.appliedBuyersId)
            {
                var temp = new Buyer();
                temp.buyerId = el;
                temp.publicBiddingId = publicBidding.publicBiddingId;
                context.Add(temp);
            }
            foreach (var el in publicBidding.biddersId)
            {
                var temp = new Bidder();
                temp.bidderId = el;
                temp.publicBiddingId = publicBidding.publicBiddingId;
                context.Add(temp);
            }
            foreach (var el in publicBidding.plotIds)
            {
                var temp = new Plot();
                temp.plotId = el;
                temp.publicBiddingId = publicBidding.publicBiddingId;
                context.Add(temp);
            }
            var bestBidder2 = new BestBidder();
            bestBidder2.bestBidderId = publicBidding.bestBidderId;
            bestBidder2.publicBiddingId = publicBidding.publicBiddingId;
            context.Add(bestBidder2);

            //var mappedWL = mapper.Map<PublicBiddingWithoutLists>(publicBiddingToUpdate);
            var newValues = mapper.Map<PublicBiddingWithoutLists>(publicBidding);
            mapper.Map(newValues, publicBiddingToUpdate);
        }

        public bool validatePublicBiddingData(PublicBiddingCreation publicBidding)
        {
            if ((publicBidding.date.Year - publicBidding.startingTime.Year == 0 &&
                publicBidding.date.Month- publicBidding.startingTime.Month == 0 &&
                publicBidding.date.Day - publicBidding.startingTime.Day == 0 &&
                publicBidding.date.Day - publicBidding.endingTime.Day == 0 &&
                publicBidding.startingTime.Hour < publicBidding.endingTime.Hour) ||
                (publicBidding.date.Year - publicBidding.startingTime.Year == 0 &&
                publicBidding.date.Month - publicBidding.startingTime.Month == 0 &&
                publicBidding.date.Day - publicBidding.startingTime.Day == 0 &&
                publicBidding.date.Day - publicBidding.endingTime.Day == 0 &&
                publicBidding.startingTime.Hour == publicBidding.endingTime.Hour &&
                publicBidding.startingTime.Minute < publicBidding.endingTime.Minute))
                return true;
            return false;
        }
    }
}
