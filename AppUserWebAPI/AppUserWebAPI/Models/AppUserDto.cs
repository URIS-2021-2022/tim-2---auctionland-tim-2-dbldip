using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Models
{
    /// <summary>
    /// Dto sent to user via response
    /// </summary>
    public class AppUserDto
    {
        public string appUserFullName { get; set; }
        public string appuserUsername { get; set; }
        public string typeOfUser { get; set; }
    }
}
