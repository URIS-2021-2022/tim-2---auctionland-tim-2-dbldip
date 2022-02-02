using OglasWebAPI.Models.SluzbeniList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Models.Oglas
{
    public class OglasDto
    {
        public DateTime DatumObjave { get; set; }

        public DateTime RokObjave { get; set; }

        public string Mesto { get; set; }

        public string Oglasivac { get; set; }

        public string Oblast { get; set; }

        public string PredmetJavneProdaje { get; set; }

        public Guid SluzbeniListId { get; set; }

        public SluzbeniListDto SluzbeniList { get; set; }
    }
}
