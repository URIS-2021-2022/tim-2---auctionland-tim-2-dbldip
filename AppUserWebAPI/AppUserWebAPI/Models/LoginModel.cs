using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Models
{
    /// <summary>
    /// Model used as a parameter for LoginMethod in LoginController
    /// </summary>
    public class LoginModel
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
