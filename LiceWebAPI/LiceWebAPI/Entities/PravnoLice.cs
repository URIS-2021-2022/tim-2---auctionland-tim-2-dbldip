using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    public class PravnoLice : Lice
    {
        public string Naziv { get; set; }
        public string Maticnibroj { get; set; }
        public string Faks { get; set; }
        public Guid KontaktOsobaId { get; set; }
        public KontaktOsoba KontaktOsoba { get; set; }
    }
}
