using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Models
{
    /// <summary>
    /// Potvrda kreiranja licitacije
    /// </summary>
    public class AuctionCreationConfirmationDto
    {
        #region Auction

        /// <summary>
        /// ID licitacije
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
        /// Lista ID-jeva javnih nadmetanja
        /// </summary>
        public List<Guid> publicBidding { get; set; }

        /// <summary>
        /// Rok zatvaranja licitacije
        /// </summary>
        public DateTime registryClosingDate { get; set; }

        #endregion
    }
}
