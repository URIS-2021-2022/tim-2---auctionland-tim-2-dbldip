using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Models
{
    public class AppUserCreationDto
    {
        public string appUserName { get; set; }
        public string appUserLastName { get; set; }
        public string appUserUsername { get; set; }
        public string appUserPassword { get; set; }
        public Guid typeOfUserId { get; set; }
        public string typeOfUser { get; set; }
    }
}
