using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;

namespace PublicBiddingAPI.Data
{
    public interface IPublicBiddingRepository
    {
        List<PublicBidding> getAllPublicBiddings();
        PublicBidding getPublicBidding(Guid biddingId);
        List<PublicBidding> getPublicBiddingsByType(Guid typeOfPublicBidding);
        List<PublicBidding> getPublicBiddingsByBestBidder(Guid bestBidderId);
        List<PublicBidding> getPublicBiddingsByAppliedBuyer(Guid buyerId);
        List<PublicBidding> getPublicBiddingsByBidder(Guid bidderId);

        List<PublicBidding> getPublicBiddingsByCadastralMunicipality(Guid cadastralMunicipalityId);

        List<PublicBidding> getPublicBiddingsByStartingPricePerHectare(double price);
        List<PublicBidding> getPublicBiddingsByLeasePeriod(double period);
        PublicBiddingConfirmation createPublicBidding(PublicBiddingCreation publicBidding);
        void DeletePublicBidding(Guid publicBiddingId);
        void UpdatePublicBidding(PublicBiddingUpdate publicBidding);
        bool SaveChanges();
        bool validatePublicBiddingData(PublicBiddingCreation publicBidding);
    }
}
