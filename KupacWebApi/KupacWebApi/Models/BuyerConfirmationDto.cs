using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Models
{
    public class BuyerConfirmationDto
    {
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
