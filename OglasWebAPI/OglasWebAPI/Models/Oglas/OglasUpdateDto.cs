using OglasWebAPI.Models.SluzbeniList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Models.Oglas
{
    /// <summary>
    /// Dto Update oglas
    /// </summary>
    public class OglasUpdateDto
    {
        /// <summary>
        /// Datum objave oglasa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum objave!")]
        public DateTime DatumObjave { get; set; }

        /// <summary>
        /// Rok objave oglasa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti rok objave!")]
        public DateTime RokObjave { get; set; }

        /// <summary>
        /// Mesto oglasa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto!")]
        public string Mesto { get; set; }

        /// <summary>
        /// Odlašivač oglasa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti oglašivača!")]
        public string Oglasivac { get; set; }

        /// <summary>
        /// Oblast oglasa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti oblast!")]
        public string Oblast { get; set; }

        /// <summary>
        /// Predmet javne nabavke oglasa
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti predmet javne nabavke!")]
        public string PredmetJavneProdaje { get; set; }

        /// <summary>
        /// Službeni lista id
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti sluzbeni list!")]
        public Guid SluzbeniListId { get; set; }

        /// <summary>
        /// Službeni list
        /// </summary>
        public SluzbeniListDto SluzbeniList { get; set; }
    }
}
