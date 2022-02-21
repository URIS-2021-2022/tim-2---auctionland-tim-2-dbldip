using AuctionAPI.Entities;
using AuctionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Data
{
    public interface IAuctionRepository
    {
        List<Auction> GetAuctionCreations();

        Auction GetAuctionCreationById(Guid auctionId);

        Auction GetAuctionCreationByNumber(int auctionNumber);

        Auction GetAuctionCreationByBiddingDate(DateTime biddingDate); 

        Auction UpdateAuctionCreation(CreationAuctionDto auctionCreation);

        Auction CreateAuctionCreation(CreationAuctionDto auctionCreation);

        void DeleteAuctionCreation(Guid auctionId);
    }
}
