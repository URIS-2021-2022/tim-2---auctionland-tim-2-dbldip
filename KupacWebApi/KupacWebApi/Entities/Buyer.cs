using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class Buyer
    {
        public Guid buyerId { get; set; }
        public Person person { get; set; }
        public int realizedArea { get; set; }
        public bool hasBan { get; set; }
        public DateTime dateOfBanStart { get; set; }
        public DateTime dateOfBanEnd { get; set; }
        public int banDuration { get; set; }
        public List <PublicBidding> publicBiddings { get; set; }
        public List<Payment> payments { get; set; }
        public List<AuthorizedPerson> authorizedPeople { get; set; }

    }
}
