using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class Address
    {
        public Guid addressId { get; set; }
        public string completeAddress { get; set; }
        public string townInfo { get; set; }
        public string country { get; set; }   
    }
}
