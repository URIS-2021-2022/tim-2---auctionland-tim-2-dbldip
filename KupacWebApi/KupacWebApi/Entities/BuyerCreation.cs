using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerCreation
    {
        public Guid personId { get; set; }
        public int realizedArea { get; set; }
        public bool hasBan { get; set; }
        public DateTime dateOfBanStart { get; set; }
        public DateTime dateOfBanEnd { get; set; }
        public int banDuration { get; set; }
        public List<Guid> publicBiddingIds { get; set; }
        public List<Guid> paymentIds { get; set; }
        public List<Guid> authorizedPeopleIds { get; set; }
    }
}
