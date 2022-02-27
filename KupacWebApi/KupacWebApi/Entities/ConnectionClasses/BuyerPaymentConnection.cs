using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities.ConnectionClasses
{
    public class BuyerPaymentConnection
    {
        [Key]
        public Guid buyerPaymentConnectionId { get; set; }
        public Guid buyerId { get; set; }
        public Guid payerId { get; set; }
    }
}
