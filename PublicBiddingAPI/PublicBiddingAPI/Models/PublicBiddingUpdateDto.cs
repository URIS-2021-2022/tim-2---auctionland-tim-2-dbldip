using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    public class PublicBiddingUpdateDto : PublicBiddingCreationDto
    {
        public Guid publicBiddingId { get; set; }
    }
}
