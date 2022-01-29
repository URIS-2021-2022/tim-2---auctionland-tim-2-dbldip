using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Entities
{
    public class Country
    {
        [Key]
        public Guid countryID { get; set; }
        public string countryName { get; set; }
    }
}
