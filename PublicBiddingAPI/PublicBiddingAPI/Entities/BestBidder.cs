using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Best bidder - winner of public bidding, used as template for a table in a database
    /// </summary>
    public class BestBidder
    {
        [Key]
        public Guid bestBidderConnectionId { get; set; }
        /// <summary>
        /// Id of public bidding in which the buyer won
        /// </summary>
        public Guid publicBiddingId { get; set; }
        /// <summary>
        /// Id of winning buyer
        /// </summary>
        public Guid bestBidderId { get; set; }
    }
}
