using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities.ConnectionClasses
{
    public class AuctionPublicBiddingConnection
    {
        [Key]
        public Guid auctionPublicBiddingConnectionId { get; set; }
        public Guid auctionId { get; set; }
        public Guid publicBiddingId { get; set; }
    }
}
