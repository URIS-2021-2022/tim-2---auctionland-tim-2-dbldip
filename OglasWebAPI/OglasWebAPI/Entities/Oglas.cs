using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Entities
{
    public class Oglas
    {
        [Key]
        public Guid OglasId { get; set; } = Guid.NewGuid();
        
        public DateTime DatumObjave { get; set; }

        public DateTime RokObjave { get; set; }

        public string Mesto { get; set; }

        public string Oglasivac { get; set; }

        public string Oblast { get; set; }

        public string PredmetJavneProdaje { get; set; }

        public Guid SluzbeniListId { get; set; }

        public SluzbeniList SluzbeniList { get; set; }

    }
}
