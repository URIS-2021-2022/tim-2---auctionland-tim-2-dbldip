using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    public class AddressConfirmationDto
    {
        public string addressStreet { get; set; }
        public string addressNumber { get; set; }
        public string addressTown { get; set; }
        public string countryName { get; set; }
    }
}
