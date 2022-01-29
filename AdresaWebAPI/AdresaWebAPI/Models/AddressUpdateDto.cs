using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    public class AddressUpdateDto
    {
        public Guid addressId { get; set; }
        public string addressStreet { get; set; }
        public string addressNumber { get; set; }
        public string addressTown { get; set; }
        public string addressMunicipality { get; set; }
        public string addressPostalCode { get; set; }
        public Guid countryId { get; set; }
        public string countryName { get; set; }
    }
}
