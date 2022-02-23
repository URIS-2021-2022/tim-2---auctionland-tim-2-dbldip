using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Cadastral Municipality in which public bidding is being held
    /// </summary>
    public class CadastralMunicipality
    {
        /// <summary>
        /// Id of cadastral municipality
        /// </summary>
        [Key]
        public Guid cadastralMuniciplaityId { get; set; }
        /// <summary>
        /// Name of cadastral municipality
        /// </summary>
        public string cadastralMunicipalityName { get; set; }
    }
}
