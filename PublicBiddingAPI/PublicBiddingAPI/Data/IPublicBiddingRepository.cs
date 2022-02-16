using PublicBiddingAPI.Entities;
using PublicBiddingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        List<PublicBidding> getPublicBiddingsByCadastralMunicipality(Guid cadastralMunicipality);
        List<PublicBidding> getPublicBiddingsByStartingPricePerHectare(double price);
        List<PublicBidding> getPublicBiddingsByLeasePeriod(double period);
        PublicBiddingConfirmationDto createPublicBidding(PublicBidding publicBidding);
        void UpdatePublicBidding(PublicBidding publicBidding);
        void DeletePublicBidding(Guid publicBiddingId);
        bool SaveChanges();
    }
}
