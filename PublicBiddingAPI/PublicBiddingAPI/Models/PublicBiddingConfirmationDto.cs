using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    public class PublicBiddingConfirmationDto
    {
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        public Guid buyerId { get; set; }
    }
}
