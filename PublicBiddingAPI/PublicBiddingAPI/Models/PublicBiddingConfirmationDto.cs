using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    /// <summary>
    /// Confirmation dto that's sent to user when creating public bidding via post request
    /// </summary>
    public class PublicBiddingConfirmationDto
    {
        /// <summary>
        /// Date of public bidding
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// start time of bidding
        /// </summary>
        public DateTime startingTime { get; set; }
        /// <summary>
        /// end time of bidding
        /// </summary>
        public DateTime endingTime { get; set; }
        /// <summary>
        /// type of bidding
        /// </summary>
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        /// <summary>
        /// bid that won the bidding
        /// </summary>
        public double bestBid { get; set; }
        /// <summary>
        /// buyer who won the bidding - his/her id
        /// </summary>
        public Guid buyerId { get; set; }
    }
}
