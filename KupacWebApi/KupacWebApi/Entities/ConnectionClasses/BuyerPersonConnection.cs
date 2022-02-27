using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities.ConnectionClasses
{
    public class BuyerPersonConnection
    {
        [Key]
        public Guid buyerPersonConnectionId { get; set; }
        public Guid buyerId { get; set; }
        public Guid personId { get; set; }
    }
}
