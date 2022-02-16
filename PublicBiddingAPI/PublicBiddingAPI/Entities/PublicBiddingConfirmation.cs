using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class PublicBiddingConfirmation
    {
        public Guid publicBiddingId { get; set; }
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        public Guid buyerId { get; set; }
    }
}
