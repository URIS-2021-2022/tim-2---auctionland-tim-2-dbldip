using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class Plot
    {
        [Key]
        public Guid plotConnectionId { get; set; }
        public Guid publicBiddingId { get; set; }
        public Guid plotId { get; set; }
        //public int surfaceArea { get; set; }
        //public int parcelNumber { get; set; }
        //public string realEstateListNumber { get; set; }
        //public string protectedZoneRealState { get; set; }
        //public Guid protectedZoneId { get; set; }
        //public int level { get; set; }
        //public Guid parcelUserId { get; set; }
        //public string name { get; set; }
        //public string surname { get; set; }
        //public string jmbg { get; set; }
        //public string address { get; set; }
        //public Guid cadastralMunicipalityId { get; set; }
        //public string nameOfCadastralMunicipality { get; set; }
        //public Guid parcelPartId { get; set; }
        //public int partSurfaceArea { get; set; }
        //public int partParcelNumber { get; set; }
        //public string partRealEstateListNumber { get; set; }
    }
}
