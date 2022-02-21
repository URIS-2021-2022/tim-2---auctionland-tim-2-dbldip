using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class Plot
    {
        [Key]
        public Guid plotConnectionId { get; set; }
        public Guid publicBiddingId { get; set; }
        public Guid plotId { get; set; }
    }
}
