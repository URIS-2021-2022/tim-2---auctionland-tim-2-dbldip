using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Entities
{
    public class SluzbeniList
    {
        [Key]
        public Guid SluzbeniListId { get; set; } = Guid.NewGuid();

        public string Broj { get; set; }

        public DateTime Datum { get; set; }

        public string Opis { get; set; }


    }
}
