using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Models
{
    /// <summary>
    /// Model kreirane licitacije
    /// </summary>
    public class AuctionDto
    {

        #region Auction
        /// <summary>
        /// ID licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID licitacije.")]
        public Guid auctionId { get; set; }

        /// <summary>
        /// Broj licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj licitacije.")]
        public int auctionNumber { get; set; }

        /// <summary>
        /// Godina licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti godinu licitacije.")]
        public int auctionYear { get; set; }


        /// <summary>
        /// Datum održavanja licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum odrzavanja licitacije.")]
        public DateTime biddingDate { get; set; }

        /// <summary>
        /// Ograničenje licitacije
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// Korak cene licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti korak cene licitacije.")]
        public int priceStep { get; set; }

        /// <summary>
        /// Lista dokumenata fizičkog lica
        /// </summary>
        public List<String> naturalPersonDocumentList { get; set; }

        /// <summary>
        /// Lista dokumenata javnog lica
        /// </summary>
        public List<String> legalPersonDocumentList { get; set; }

        /// <summary>
        /// Lista ID-jeva javnog nadmetanja
        /// </summary>
        List<Guid> publicBidding { get; set; }

        /// <summary>
        /// Rok zatvaranja prijava na licitaciju
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti rok zatvaranja prijava na licitacij.")]
        public DateTime registryClosingDate { get; set; }

        #endregion
    }
}
