using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities.ManyToMany
{
    /// <summary>
    /// Predstavlja many-to-many tabelu LicitacijaJavnoNadmetanje
    /// </summary>
    public class AuctionPublicBidding
    {
        /// <summary>
        /// Id licitacije
        /// </summary>
        public Guid auctionId { get; set; }

        /// <summary>
        /// Objekat licitacije
        /// </summary>
        public Auction auction { get; set; }

        /// <summary>
        /// Id javnog nadmetanja
        /// </summary>
        public Guid publicBiddingId { get; set; }
    }
}
