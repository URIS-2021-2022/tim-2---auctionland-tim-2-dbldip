using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Models
{
    public class AuthorizedPersonConfirmationDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string jmbg { get; set; }
        public List<int> tableNumber { get; set; }

    }
}
