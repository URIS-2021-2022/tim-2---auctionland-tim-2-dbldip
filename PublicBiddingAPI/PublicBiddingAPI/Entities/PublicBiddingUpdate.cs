using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class PublicBiddingUpdate : PublicBiddingCreation
    {
        public Guid publicBiddingId { get; set; }
    }
}
