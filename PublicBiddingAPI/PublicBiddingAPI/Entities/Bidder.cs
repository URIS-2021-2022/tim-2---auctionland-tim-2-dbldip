using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class Bidder
    {
        [Key]
        public Guid bidderConnectionId { get; set; }
        public Guid publicBiddingId { get; set; }
        public Guid bidderId { get; set; }
        //public string bidderFirstName { get; set; }
        //public string bidderLastName { get; set; }
        //public List<int> tableNumbers { get; set; }
        //public List<Guid> buyersId { get; set; }
    }
}
