using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    public class PersonConfirmationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }

        //public Guid CommissionId { get; set; }
       // public Commission Commission { get; set; }
    }
}
