using OglasWebAPI.Models.SluzbeniList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Models.Oglas
{
    public class OglasCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti datum objave!")]
        public DateTime DatumObjave { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti rok objave!")]
        public DateTime RokObjave { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti mesto!")]
        public string Mesto { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti oglašivača!")]
        public string Oglasivac { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti oblast!")]
        public string Oblast { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti predmet javne nabavke!")]
        public string PredmetJavneProdaje { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti sluzbeni list!")]
        public Guid SluzbeniListId { get; set; }

        public SluzbeniListDto SluzbeniList { get; set; }
    }
}
