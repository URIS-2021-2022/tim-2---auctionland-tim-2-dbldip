using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Models
{
    public class BuyerUpdateDto : BuyerCreationDto
    {
        /// <summary>
        /// Buyer ID
        /// </summary>
        public Guid buyerId { get; set; }
    }
}
