using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    /// <summary>
    /// Dto sent to the server while Updating public bidding via PUT request
    /// </summary>
    public class PublicBiddingUpdateDto : PublicBiddingCreationDto
    {
        /// <summary>
        /// Adding id to the creation dto 
        /// </summary>
        public Guid publicBiddingId { get; set; }
    }
}
