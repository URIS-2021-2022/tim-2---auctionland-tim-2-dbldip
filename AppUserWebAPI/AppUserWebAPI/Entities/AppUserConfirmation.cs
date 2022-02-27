using System;
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
        /// <summary>
        /// newly created user id
        /// </summary>
        public Guid appUserId { get; set; }
        /// <summary>
        /// newly created user first name
        /// </summary>
        public string appUserName { get; set; }
        /// <summary>
        /// newly created user last name
        /// </summary>
        public string appUserLastName { get; set; }
        /// <summary>
        /// newly created user type of user
        /// </summary>
        public string typeOfUser { get; set; }
    }
}
