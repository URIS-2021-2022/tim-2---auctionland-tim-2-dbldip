using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class Parcel
    {
        [Key]
        public Guid parcelId { get; set; }
        public int surfaceArea { get; set; }
        public int parcelNumber { get; set; }
        public string realEstateListNumber {get;set;}
        public string protectedZoneRealState { get; set; }

        #region ProtectedZone
        public Guid protectedZoneId { get; set; }
        public int level { get; set; }
        #endregion

        #region ParcelUser

        public Guid parcelUserId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string jmbg { get; set; }
        public string address { get; set; }
        #endregion

        #region CadastralMunicipality
        public Guid cadastralMunicipalityId { get; set; }
        public String nameOfCadastralMunicipality { get; set; }
        #endregion

        #region ParcelPart
        public Guid parcelPartId { get; set; }
        public int partSurfaceArea { get; set; }
        public int partParcelNumber { get; set; }
        public string partRealEstateListNumber { get; set; }
        #endregion

    }
}
