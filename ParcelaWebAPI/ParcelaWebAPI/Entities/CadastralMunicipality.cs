using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class CadastralMunicipality
    {
        /// <summary>
        /// Cadastral Municipality ID
        /// </summary>
        [Key]
        public Guid cadastralMunicipalityId { get; set; }
        /// <summary>
        /// name of Cadastral Municipality
        /// </summary>
        public string nameOfCadastralMunicipality { get; set; }

    }
}
