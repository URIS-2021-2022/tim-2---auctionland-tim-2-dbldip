using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelDtos
{
    public class ParcelConfirmationDto
    {
        /// <summary>
        /// surface area
        /// </summary>
        public int surfaceArea { get; set; }
        /// <summary>
        /// parcel number
        /// </summary>
        public int parcelNumber { get; set; }
        /// <summary>
        /// Real estate list number
        /// </summary>
        public string realEstateListNumber { get; set; }
        /// <summary>
        /// Real state of protected zone
        /// </summary>
        public string protectedZoneRealState { get; set; }
        /// <summary>
        /// Parcel user's name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Parcel user's surname
        /// </summary>
        public string surname { get; set; }
        /// <summary>
        /// name of Cadastral Municipality
        /// </summary>
        public string nameOfCadastralMunicipality { get; set; }
        /// <summary>
        /// Surface area of part
        /// </summary>
        public int partSurfaceArea { get; set; }
    }
}
