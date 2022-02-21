using AuctionAPI.Entities;
using AuctionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Data
{
    public interface IAuctionCreationRepository
    {
        List<AuctionCreation> GetAuctionCreations();

        AuctionCreation GetAuctionCreationById(Guid auctionId);

        AuctionCreation GetAuctionCreationByNumber(int auctionNumber);

        AuctionCreation GetAuctionCreationByBiddingDate(DateTime biddingDate); 

        AuctionCreation UpdateAuctionCreation(CreationDto auctionCreation);

        AuctionCreation CreateAuctionCreation(CreationDto auctionCreation);

        void DeleteAuctionCreation(Guid auctionId);
    }
}
