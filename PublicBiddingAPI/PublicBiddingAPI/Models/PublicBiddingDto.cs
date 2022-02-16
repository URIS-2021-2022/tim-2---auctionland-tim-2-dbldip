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
        public List<Guid> plots { get; set; }
        public double bestBid { get; set; }
        public Guid bestBidder { get; set; }
        public double leasePeriod { get; set; }
    }
}
