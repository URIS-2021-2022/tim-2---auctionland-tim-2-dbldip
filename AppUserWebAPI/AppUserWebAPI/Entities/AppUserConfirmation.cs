﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Entities
{
    /// <summary>
    /// Confirmation entity used to confirm creating users
    /// </summary>
    public class AppUserConfirmation
    {
        public Guid appUserId { get; set; }
        public string appUserName { get; set; }
        public string appUserLastName { get; set; }
        public string typeOfUser { get; set; }
    }
}
