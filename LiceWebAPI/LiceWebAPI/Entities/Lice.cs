using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Entities
{
    public abstract class Lice
    {
        [Key]
        public Guid LiceId { get; set; } = Guid.NewGuid();
        public string BrojTelefona { get; set; }
        public string BrojTelefona2 { get; set; }
        public string Email { get; set; }
        public string BrojRacuna { get; set; }
        public Guid? AdresaId { get; set; } 
    }
}
