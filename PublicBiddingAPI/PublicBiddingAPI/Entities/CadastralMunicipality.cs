using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class CadastralMunicipality
    {
        [Key]
        public Guid cadastralMuniciplaityId { get; set; }
        public string cadastralMunicipalityName { get; set; }
    }
}
