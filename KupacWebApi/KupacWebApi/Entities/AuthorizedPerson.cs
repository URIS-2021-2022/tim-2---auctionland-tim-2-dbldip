using KupacWebApi.Entities.ConnectionClasses;
using KupacWebApi.Entities.OtherAgregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class AuthorizedPerson
    {
        public Guid authorizedPersonId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string jmbg { get; set; }
        public List<AuthorizedPersonBuyerConnection> buyers { get; set; }
        public List<int> tableNumber { get; set; }
        public Address address { get; set; }
        public Country country { get; set; }
        public bool isDelete { get; set; }
    }
}
