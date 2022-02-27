using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerUpdate : BuyerCreation
    {
        /// <summary>
        /// Buyer ID
        /// </summary>
        public Guid buyerId { get; set; }
    }
}
