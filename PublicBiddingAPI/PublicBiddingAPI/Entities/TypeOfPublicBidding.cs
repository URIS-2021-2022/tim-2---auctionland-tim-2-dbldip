using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Type of public bidding entity
    /// </summary>
    public class TypeOfPublicBidding
    {
        public Guid typeOfPublicBiddingId { get; set; }
        /// <summary>
        /// Name of type
        /// </summary>
        public string typeOfPublicBiddingName { get; set; }
    }
}
