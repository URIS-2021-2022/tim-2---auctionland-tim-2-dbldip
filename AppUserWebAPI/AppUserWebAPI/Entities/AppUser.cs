﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Entities
{
    /// <summary>
    /// AppUser entity, used as a template for database
    /// </summary>
    public class AppUser
    {
        /// <summary>
        /// Id property of user, generated by EF
        /// </summary>
        public Guid appUserId { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string appUserName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        public string appUserLastName { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string appUserUsername { get; set; }
        /// <summary>
        /// Password, will be hashed in database
        /// </summary>
        public string appUserPassword { get; set; }
        /// <summary>
        /// Type id 
        /// </summary>
        public Guid typeOfUserId { get; set; }
        public string typeOfUser { get; set; }

    }
}
