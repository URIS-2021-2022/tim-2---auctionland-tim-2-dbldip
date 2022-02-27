using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintAPI.Models.Buyer
{
    /// <summary>
    /// Dto Kupac - Entitet iz drugog mikroservisa
    /// </summary>
    public class BuyerDto
    {
        /// <summary>
        /// ID kupca
        /// </summary>
        public Guid personId { get; set; }


        /// <summary>
        /// Ostvarena površina kupca
        /// </summary>
        public int realizedArea { get; set; }

        /// <summary>
        /// Da li kupac ima zabranu?
        /// </summary>
        public bool hasBan { get; set; }

        /// <summary>
        /// Datum početka zabrane
        /// </summary>
        public DateTime dateOfBan { get; set; }

        /// <summary>
        /// Dužina trajanja zabrane u godinama
        /// </summary>
        public int banDuration { get; set; }

        /// <summary>
        /// Datum završetka zabrane
        /// </summary>
        public DateTime dateOfBanEnd { get; set; }

    }
}
