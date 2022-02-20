using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities.ConnectionClasses
{
    public class AuthorizedPersonBuyerConnection
    {
        [Key]
        public Guid authorizedPersonBuyerConnectionId { get; set; }
        public Guid authorizedPersonId { get; set; }
        public Guid buyerId { get; set; }
    }
}
