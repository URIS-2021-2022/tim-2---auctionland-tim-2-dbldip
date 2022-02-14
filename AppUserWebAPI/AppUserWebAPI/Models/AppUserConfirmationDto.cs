using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Models
{
    public class AppUserConfirmationDto
    {

        public string appUserName { get; set; }
        public string appUserLastName { get; set; }
        public string typeOfUser { get; set; }
    }
}
