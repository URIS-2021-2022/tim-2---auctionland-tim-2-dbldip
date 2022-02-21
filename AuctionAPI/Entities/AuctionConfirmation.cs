using AuctionAPI.Entities.ConnectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    public class AuctionConfirmation
    {
        public Guid auctionId { get; set; }
        public int auctionNumber { get; set; }
        public DateTime biddingDate { get; set; }
        public List<AuctionPublicBiddingConnection> publicBidding { get; set; }
        public DateTime registryClosingDate { get; set; }
    }
}
