using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelDtos
{
    public class ParcelCreationDto
    {
        [Required]
        public int surfaceArea { get; set; }
        [Required]
        public int parcelNumber { get; set; }
        [Required]
        public string realEstateListNumber { get; set; }
        [Required]
        public string protectedZoneRealState { get; set; }
        [Required]
        public Guid protectedZoneId { get; set; }
        [Required]
        public int level { get; set; }
        [Required]
        public Guid parcelUserId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string jmbg { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public Guid cadastralMunicipalityId { get; set; }
        [Required]
        public string nameOfCadastralMunicipality { get; set; }
        [Required]
        public Guid parcelPartId { get; set; }
        [Required]
        public int partSurfaceArea { get; set; }
        [Required]
        public int partParcelNumber { get; set; }
        [Required]
        public string partRealEstateListNumber { get; set; }
    }
}
