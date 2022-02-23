using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Models
{
    /// <summary>
    /// Model izmene licitacije
    /// </summary>
    public class AuctionUpdate
    {
        /// <summary>
        /// ID licitacije
        /// </summary>
        [Required(ErrorMessage ="Obavezno je uneti ID licitacije.")]
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
        /// Lista dokumenata ficičkog lica
        /// </summary>
        public List<String> naturalPersonDocumentList { get; set; }

        /// <summary>
        /// Lista dokumenata javnog lica
        /// </summary>
        public List<String> legalPersonDocumentList { get; set; }

        /// <summary>
        /// Lista ID-jeva javnih nadmetanja
        /// </summary>
        public List<Guid> publicBiddingIds { get; set; }

        /// <summary>
        /// Rok zatvaranja prijava na licitaciju
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti rok zatvaranja prijava na licitaciju.")]
        public DateTime registryClosingDate { get; set; }
    }
}
