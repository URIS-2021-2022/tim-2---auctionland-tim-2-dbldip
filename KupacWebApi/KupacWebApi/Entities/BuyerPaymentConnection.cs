using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerPaymentConnection
    {
        public Guid buyerPaymentConnectionId { get; set; }
        public Guid buyerId { get; set; }
        public Guid paymentId { get; set; }
    }
}
