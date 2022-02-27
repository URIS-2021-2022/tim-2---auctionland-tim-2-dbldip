using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    /// <summary>
    /// Dto that represents data sent to the user when requesting something from PublicBiddingController
    /// </summary>
    public class PublicBiddingDto
    {
        /// <summary>
        /// Date that public bidding is being held on 
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// Start time of public bidding
        /// </summary>
        public DateTime startingTime { get; set; }
        /// <summary>
        /// End time of public bidding
        /// </summary>
        public DateTime endingTime { get; set; }
        /// <summary>
        /// Plots being auctioned on public bidding
        /// </summary>
        public List<Plot> plots { get; set; }
        /// <summary>
        /// Bid that won the public bidding
        /// </summary>
        public double bestBid { get; set; }
        /// <summary>
        /// Person that won the auction - public bidding
        /// </summary>
        public BestBidder bestBidder { get; set; }
        /// <summary>
        /// Period that plot is being leased on
        /// </summary>
        public double leasePeriod { get; set; }
    }
}
