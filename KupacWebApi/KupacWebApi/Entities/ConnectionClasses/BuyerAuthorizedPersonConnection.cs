using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities.ConnectionClasses
{
    public class BuyerAuthorizedPersonConnection
    {
        [Key]
        public Guid buyerAuthorizedPersonConnectionId { get; set; }
        public Guid buyerId { get; set; }
        public Guid authorizedPersonId { get; set; }
    }
}
