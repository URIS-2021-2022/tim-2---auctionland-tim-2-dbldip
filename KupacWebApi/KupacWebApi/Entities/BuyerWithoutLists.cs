using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class BuyerWithoutLists
    {
        public Guid buyerId { get; set; }
        public Person person { get; set; }
        public int realizedArea { get; set; }
        public bool hasBan { get; set; }
        public DateTime dateOfBanStart { get; set; }
        public DateTime dateOfBanEnd { get; set; }
        public int banDuration { get; set; }
    }
}
