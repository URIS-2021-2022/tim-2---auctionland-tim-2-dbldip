using KupacWebApi.Entities.ConnectionClasses;
using KupacWebApi.Entities.OtherAgregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class Buyer
    {
        /// <summary>
        /// Buyer ID
        /// </summary>
        public Guid buyerId { get; set; }
        /// <summary>
        /// Person
        /// </summary>
        public BuyerPersonConnection person { get; set; }
        /// <summary>
        /// Buyer's realized area
        /// </summary>
        public int realizedArea { get; set; }
        /// <summary>
        /// Check if buyer has been banned on some public biddings
        /// </summary>
        public bool hasBan { get; set; }
        /// <summary>
        /// Date of ban start
        /// </summary>
        public DateTime dateOfBanStart { get; set; }
        /// <summary>
        /// Date of ban end
        /// </summary>
        public DateTime dateOfBanEnd { get; set; }
        /// <summary>
        /// Ban duration
        /// </summary>
        public int banDuration { get; set; }
        /// <summary>
        /// List of IDs - Buyer and Public bidding
        /// </summary>
        public List <BuyerPublicBiddingConnection> publicBiddings { get; set; }
        /// <summary>
        /// List of IDs - Buyer and Payment
        /// </summary>
        public List<BuyerPaymentConnection> payments { get; set; }
        /// <summary>
        /// List of IDs - Buyer and Authorized Person
        /// </summary>
        public List<BuyerAuthorizedPersonConnection> authorizedPeople { get; set; }
        /// <summary>
        /// Delete check property
        /// </summary>
        public bool isDelete { get; set; }

    }
}
