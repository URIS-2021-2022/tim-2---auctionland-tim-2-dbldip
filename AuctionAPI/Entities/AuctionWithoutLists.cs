using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Entities
{
    public class AuctionWithoutLists
    {
        /// <summary>
        /// ID aukcije
        /// </summary>
        [Key]
        public Guid auctionId { get; set; }

        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int auctionNumber { get; set; }

        /// <summary>
        /// Godina održavanja licitacije
        /// </summary>
        public int auctionYear { get; set; }

        /// <summary>
        /// Datum održavanja licitacije
        /// </summary>
        public DateTime biddingDate { get; set; }

        /// <summary>
        /// Ograničenje
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// Korak cene
        /// </summary>
        public int priceStep { get; set; }

        /// <summary>
        /// Rok za dostavljanje prijava
        /// </summary>
        public DateTime registryClosingDate { get; set; }
    }
}
