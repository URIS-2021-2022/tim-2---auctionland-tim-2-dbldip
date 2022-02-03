using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class CadastralMunicipality
    {
        [Key]
        public Guid cadastralMunicipalityId { get; set; }
        public string nameOfCadastralMunicipality { get; set; }

    }
}
