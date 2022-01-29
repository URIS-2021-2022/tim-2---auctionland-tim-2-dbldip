using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    public class AddressDto
    {
        public Guid addressId { get; set; }
        public string completeAddress { get; set; }
        public string townInfo { get; set; }
        public string country { get; set; }
    }
}
