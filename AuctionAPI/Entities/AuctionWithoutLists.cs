using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    public class AuctionWithoutLists
    {
        public Guid auctionId { get; set; }
        public int auctionNumber { get; set; }
        public int auctionYear { get; set; }
        public DateTime biddingDate { get; set; }
        public int limit { get; set; }
        public int priceStep { get; set; }
        public DateTime registryClosingDate { get; set; }
    }
}
