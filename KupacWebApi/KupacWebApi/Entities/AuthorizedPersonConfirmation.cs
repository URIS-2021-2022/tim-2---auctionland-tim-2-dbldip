using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class AuthorizedPersonConfirmation
    {
        public Guid authorizedPersonId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string jmbg { get; set; }
        public List<Guid> buyerIds { get; set; }
        public List<int> tableNumber { get; set; }
        public Guid addressId { get; set; }
        public Guid countryId { get; set; }
    }
}
