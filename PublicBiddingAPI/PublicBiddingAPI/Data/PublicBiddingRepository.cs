using AutoMapper;
using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public PublicBiddingConfirmationDto createPublicBidding(PublicBidding publicBidding)
        {
            var createdEntity = context.Add(publicBidding);
            return mapper.Map<PublicBiddingConfirmationDto>(createdEntity.Entity);
        }

        public void DeletePublicBidding(Guid publicBiddingId)
        {
            //NOT IMPLEMENTED YET
        }

        public List<PublicBidding> getAllPublicBiddings()
        {
            return context.PublicBiddings.ToList();
        }

        public PublicBidding getPublicBidding(Guid biddingId)
        {
            return context.PublicBiddings.FirstOrDefault(e => e.publicBiddingId == biddingId);
        }

        public List<PublicBidding> getPublicBiddingsByAppliedBuyer(Guid buyerId)
        {
            return context.PublicBiddings.Where(e => e.appliedBuyersIds.Contains(buyerId)).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByBestBidder(Guid bestBidderId)
        {
            return context.PublicBiddings.Where(e => e.buyerId == bestBidderId).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByBidder(Guid bidderId)
        {
            return context.PublicBiddings.Where(e => e.biddersIds.Contains(bidderId)).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByCadastralMunicipality(Guid cadastralMunicipalityId)
        {
            return context.PublicBiddings.Where(e => e.cadastralMunicipality.cadastralMuniciplaityId == cadastralMunicipalityId).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByLeasePeriod(double period)
        {
            return context.PublicBiddings.Where(e => e.leasePeriod == period).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByStartingPricePerHectare(double price)
        {
            return context.PublicBiddings.Where(e => e.startingPricePerHectare == price).ToList();
        }

        public List<PublicBidding> getPublicBiddingsByType(Guid typeOfPublicBidding)
        {
            return context.PublicBiddings.Where(e => e.typeOfPublicBidding.typeOfPublicBiddingId == typeOfPublicBidding).ToList();
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
