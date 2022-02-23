using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class CadastralMunicipalityConfirmation
    {
        /// <summary>
        /// Cadastral Municipality ID
        /// </summary>
        public Guid cadastralMunicipalityId { get; set; }
        /// <summary>
        /// name of Cadastral Municipality
        /// </summary>
        public string nameOfCadastralMunicipality { get; set; }
    }
}
