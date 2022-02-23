using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Entities
{
    /// <summary>
    /// Type of user entity, used as a template for database
    /// </summary>
    public class TypeOfUser
    {
        /// <summary>
        /// Typeid
        /// </summary>
        public Guid typeOfUserId { get; set; }
        /// <summary>
        /// name of type
        /// </summary>
        public string typeOfUser { get; set; }
    }
}
