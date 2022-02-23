using AuctionAPI.Entities.ConnectionClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    public class Auction
    {
        [Key]
        public Guid auctionId { get; set; }
        public int auctionNumber { get; set; }
        public int auctionYear { get; set; }
        public DateTime biddingDate { get; set; }
        public int limit { get; set; }
        public int priceStep { get; set; }
        public List<String> naturalPersonDocumentList { get; set; }
        public List<String> legalPersonDocumentList { get; set; }
        
        public List<AuctionPublicBiddingConnection> publicBiddings { get; set; }
        public DateTime registryClosingDate { get; set; }
    }
}
