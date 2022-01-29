using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Entities
{
    public class CountryConfirmation
    {
        public Guid countryId { get; set; }
        public string countryName { get; set; }
    }
}
