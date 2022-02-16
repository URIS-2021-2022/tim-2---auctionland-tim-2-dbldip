using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class Buyer
    {
        public Guid personId { get; set; }
        public double personalProperty { get; set; }
        public bool hasBan { get; set; }

    }
}
