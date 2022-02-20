using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities.ConnectionClasses
{
    public class BuyerPublicBiddingConnection
    {
        [Key]
        public Guid buyerPublicBiddingConnectionId { get; set; }
        public Guid buyerId { get; set; }
        public Guid publicBiddingId { get; set; }
    }
}
