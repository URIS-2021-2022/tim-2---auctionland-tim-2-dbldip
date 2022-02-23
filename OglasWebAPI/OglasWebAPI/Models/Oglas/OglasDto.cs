using OglasWebAPI.Models.SluzbeniList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Models.Oglas
{
    /// <summary>
    /// Dto Oglas
    /// </summary>
    public class OglasDto
    {
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
        public SluzbeniListDto SluzbeniList { get; set; }
    }
}
