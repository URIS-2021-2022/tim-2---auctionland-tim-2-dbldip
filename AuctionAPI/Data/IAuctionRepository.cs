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
        List<AuctionWithoutLists> GetAuctions();

        AuctionWithoutLists CreateAuction(CreationAuctionDto auctionCreation);

        AuctionWithoutLists GetAuctionById(Guid auctionId);

        AuctionWithoutLists GetAuctionByNumber(int auctionNumber);

        void UpdateAuction(CreationAuctionDto auctionCreation);

        void DeleteAuction(Guid auctionId);
    }
}
