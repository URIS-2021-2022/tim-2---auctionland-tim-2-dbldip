using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }
}
