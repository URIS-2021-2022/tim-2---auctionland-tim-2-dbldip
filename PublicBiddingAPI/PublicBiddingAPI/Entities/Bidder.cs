using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class Bidder
    {
        public string bidderFirstName { get; set; }
        public string bidderLastName { get; set; }
        public List<int> tableNumbers { get; set; }
        public List<Guid> buyersId { get; set; }
    }
}
