
using AuctionAPI.Entities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    /// <summary>
    /// Predstavlja potvrdu licitacije
    /// </summary>
    public class AuctionConfirmation
    {
        /// <summary>
        /// Id licitacije
        /// </summary>
        public Guid auctionId { get; set; }

        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int auctionNumber { get; set; }

        /// <summary>
        /// Datum održavanja licitacije
        /// </summary>
        public DateTime biddingDate { get; set; }

        /// <summary>
        /// Lista javnih nadmetanja
        /// </summary>
        public List<AuctionPublicBidding> publicBidding { get; set; }

        /// <summary>
        /// Rok za dostavljanje prijava
        /// </summary>
        public DateTime registryClosingDate { get; set; }
    }
}
