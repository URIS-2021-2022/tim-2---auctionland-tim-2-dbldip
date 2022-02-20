using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerAuthorizedPersonConnection
    {
        public Guid buyerAuthorizedPersonConnectionId { get; set; }
        public Guid buyerId { get; set; }
        public Guid authorizedPersonId { get; set; }
    }
}
