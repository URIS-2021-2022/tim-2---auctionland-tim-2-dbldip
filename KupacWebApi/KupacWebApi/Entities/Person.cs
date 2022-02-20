using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class Person
    {
        public Guid personId { get; set; }
        public string name { get; set; }
        public Address address { get; set; } 
    }
}
