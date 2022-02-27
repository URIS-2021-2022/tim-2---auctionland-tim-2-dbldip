using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Entities
{
    /// <summary>
    /// Entitet oglas
    /// </summary>
    public class Oglas
    {
        /// <summary>
        /// Id olgasa
        /// </summary>
        [Key]
        public Guid OglasId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Datum objave oglasa
        /// </summary>
        public DateTime DatumObjave { get; set; }

        /// <summary>
        /// Rok objave oglasa
        /// </summary>
        public DateTime RokObjave { get; set; }

        /// <summary>
        /// Mesto oglasa
        /// </summary>
        public string Mesto { get; set; }

        /// <summary>
        /// Oglašivač oglasa
        /// </summary>
        public string Oglasivac { get; set; }

        /// <summary>
        /// Oblast oglasa 
        /// </summary>
        public string Oblast { get; set; }

        /// <summary>
        /// Predmet javne nabavke oglasa
        /// </summary>
        public string PredmetJavneProdaje { get; set; }

        /// <summary>
        /// Službeni list id
        /// </summary>
        public Guid SluzbeniListId { get; set; }

        /// <summary>
        /// Službeni list
        /// </summary>
        public SluzbeniList SluzbeniList { get; set; }

    }
}
