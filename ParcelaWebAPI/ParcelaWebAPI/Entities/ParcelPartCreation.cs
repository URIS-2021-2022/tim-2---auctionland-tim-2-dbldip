using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ParcelPartCreation
    {
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
