using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities.OtherAgregates
{
    [Keyless]

    public class Person
    {
        public string name { get; set; }
        public Address address { get; set; } 
    }
}
