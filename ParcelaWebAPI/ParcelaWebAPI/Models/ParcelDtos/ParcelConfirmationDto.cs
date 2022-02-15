using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelDtos
{
    public class ParcelConfirmationDto
    {
        public int surfaceArea { get; set; }
        public int parcelNumber { get; set; }
        public string realEstateListNumber { get; set; }
        public string protectedZoneRealState { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string nameOfCadastralMunicipality { get; set; }
        public int partSurfaceArea { get; set; }
    }
}
