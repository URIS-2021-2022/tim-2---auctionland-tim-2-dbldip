using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerPublicBiddingConnection
    {
        public Guid buyerPublicBiddingConnectionId { get; set; }
        public Guid buyerId { get; set; }
        public Guid pubiicBiddingId { get; set; }
    }
}
