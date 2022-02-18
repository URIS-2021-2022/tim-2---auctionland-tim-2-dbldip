using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    public class PublicBiddingDto
    {
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public List<Plot> plots { get; set; }
        public double bestBid { get; set; }
        public BestBidder bestBidder { get; set; }
        public double leasePeriod { get; set; }
    }
}
