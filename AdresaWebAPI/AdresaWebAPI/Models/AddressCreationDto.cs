using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Models
{
    public class AddressCreationDto
    {
        [Required]
        public string addressStreet { get; set; }
        [Required]
        public string addressNumber { get; set; }
        [Required]
        public string addressTown { get; set; }
        [Required]
        public string addressMunicipality { get; set; }
        [Required]
        public string addressPostalCode { get; set; }
        public Guid countryId { get; set; }
        public string countryName { get; set; }
    }
}
