using KupacWebApi.Entities.OtherAgregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerWithoutLists
    {
        /// <summary>
        /// Buyer ID
        /// </summary>
        [Key]
        public Guid buyerId { get; set; }
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
    }
}
