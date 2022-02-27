using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelDtos
{
    public class ParcelUpdateDto
    {
        public Guid parcelId { get; set; }
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
        /// Protected zone ID
        /// </summary>
        public Guid protectedZoneId { get; set; }
        /// <summary>
        /// Number of level
        /// </summary>
        public int level { get; set; }

        /// <summary>
        /// Parcel user ID
        /// </summary>
        public Guid parcelUserId { get; set; }
        /// <summary>
        /// Parcel user's name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Parcel user's surname
        /// </summary>
        public string surname { get; set; }
        /// <summary>
        /// Parcel user's jmbg
        /// </summary>
        public string jmbg { get; set; }
        /// <summary>
        /// Parcel user's address
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// Cadastral Municipality ID
        /// </summary>
        public Guid cadastralMunicipalityId { get; set; }
        /// <summary>
        /// name of Cadastral Municipality
        /// </summary>
        public string nameOfCadastralMunicipality { get; set; }
        /// <summary>
        /// Parcel part ID
        /// </summary>
        public Guid parcelPartId { get; set; }
        /// <summary>
        /// Surface area of part
        /// </summary>
        public int partSurfaceArea { get; set; }
        /// <summary>
        /// Parcel part number
        /// </summary>
        public int partParcelNumber { get; set; }
        /// <summary>
        /// Real estate number of parcel part
        /// </summary>
        public string partRealEstateListNumber { get; set; }
    }
}
