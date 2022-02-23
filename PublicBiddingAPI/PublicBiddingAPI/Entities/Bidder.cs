using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Bidder entity, used as template for a table that connects public bidding with applied bidders
    /// </summary>
    public class Bidder
    {
        [Key]
        public Guid bidderConnectionId { get; set; }
        /// <summary>
        /// Public bidding in which bidders are competing
        /// </summary>
        public Guid publicBiddingId { get; set; }
        /// <summary>
        /// bidder that competes in specified public bidding
        /// </summary>
        public Guid bidderId { get; set; }
    }
}
