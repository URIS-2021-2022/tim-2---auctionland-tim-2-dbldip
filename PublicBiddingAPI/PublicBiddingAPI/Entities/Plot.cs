using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Connection entity between public bidding and plots that are being auctioned
    /// </summary>
    public class Plot
    {
        [Key]
        public Guid plotConnectionId { get; set; }
        /// <summary>
        /// Public bidding that plots are being auctioned on
        /// </summary>
        public Guid publicBiddingId { get; set; }
        /// <summary>
        /// Id of a plot that is being auctioned
        /// </summary>
        public Guid plotId { get; set; }
    }
}
