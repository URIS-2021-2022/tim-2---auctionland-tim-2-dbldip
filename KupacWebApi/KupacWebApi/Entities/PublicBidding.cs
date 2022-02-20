using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class PublicBidding
    {
        public Guid publicBiddingId { get; set; }

        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public double bestBid { get; set; }
        public double leasePeriod { get; set; }
    }
}
