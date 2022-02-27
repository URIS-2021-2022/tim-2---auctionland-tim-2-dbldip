using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ParcelPart
    {
        /// <summary>
        /// Parcel part ID
        /// </summary>
        [Key]
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
