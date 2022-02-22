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
        List<Auction> GetAuctions();

        Auction CreateAuction(CreationAuctionDto auctionCreation);

        Auction GetAuctionById(Guid auctionId);

        Auction GetAuctionByNumber(int auctionNumber);

        Auction UpdateAuction(CreationAuctionDto auctionCreation);

        void DeleteAuction(Guid auctionId);
    }
}
