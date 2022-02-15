using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelUserDtos
{
    public class ParcelUserCreationDto
    {
        [Required]

        public string name { get; set; }
        [Required]

        public string surname { get; set; }
        [Required]

        public string jmbg { get; set; }
        [Required]

        public string address { get; set; }
    }
}
