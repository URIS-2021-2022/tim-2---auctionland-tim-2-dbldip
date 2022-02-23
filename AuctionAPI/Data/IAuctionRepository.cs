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

        AuctionConfirmation CreateAuction(CreationAuctionDto auctionCreation);

        Auction GetAuctionById(Guid auctionId);

        Auction GetAuctionByNumber(int auctionNumber);

        void UpdateAuction(AuctionUpdate auction);

        void DeleteAuction(Guid auctionId);

        void SaveChanges();
    }
}
