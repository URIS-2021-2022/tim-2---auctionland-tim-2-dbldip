using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities.OtherAgregates
{
    public class Address
    {
        public Guid addressId { get; set; }
        public string completeAddress { get; set; }
        public string townInfo { get; set; }
        public string country { get; set; }   
    }
}
