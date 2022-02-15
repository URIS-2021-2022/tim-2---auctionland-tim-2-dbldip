using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelPartDtos
{
    public class ParcelPartCreationDto
    {
        [Required]
        public int partSurfaceArea { get; set; }
        [Required]
        public int partParcelNumber { get; set; }
        [Required]
        public string partRealEstateListNumber { get; set; }
    }
}
