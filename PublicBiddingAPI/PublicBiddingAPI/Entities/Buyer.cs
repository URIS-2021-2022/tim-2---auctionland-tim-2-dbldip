using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Buyer entity, used as template for a table that connects public bidding with applied buyers
    /// </summary>
    public class Buyer
    {
        [Key]
        public Guid buyerConnectionId { get; set; }
        /// <summary>
        /// Public bidding which buyers are applied to
        /// </summary>
        public Guid publicBiddingId { get; set; }
        /// <summary>
        /// Buyer that is applied to specified public bidding
        /// </summary>
        public Guid buyerId { get; set; }

    }
}
