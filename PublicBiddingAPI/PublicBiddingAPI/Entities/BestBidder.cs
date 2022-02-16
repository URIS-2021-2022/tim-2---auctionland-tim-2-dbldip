using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class BestBidder
    {
        [Key]
        public Guid bestBidderConnectionId { get; set; }
        public Guid publicBiddingId { get; set; }
        public Guid bestBidderId { get; set; }
        //public Guid personId { get; set; }
        //public double personalProperty { get; set; }
        //public bool hasBan { get; set; }
    }
}
