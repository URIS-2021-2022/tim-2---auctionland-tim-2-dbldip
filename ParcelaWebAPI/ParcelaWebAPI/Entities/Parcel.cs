using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class Parcel
    {
        public int surfaceArea { get; set; }
        public int parcelNumber { get; set; }

        #region ProtectedZone
        public Guid protectedZoneId { get; set; }
        public int level { get; set; }
        #endregion

        public string realEstateListNumber {get;set;}


    }
}
