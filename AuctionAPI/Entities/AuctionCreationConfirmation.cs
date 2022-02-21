using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    public class AuctionCreationConfirmation
    {
        public Guid auctionId { get; set; }
        public int auctionNumber { get; set; }
        public DateTime biddingDate { get; set; }
        //public List<PublicBidding> publicBidding { get; set; }
        public DateTime registryClosingDate { get; set; }
    }
}
