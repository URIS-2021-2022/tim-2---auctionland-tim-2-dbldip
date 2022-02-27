using KupacWebApi.Entities.OtherAgregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class AuthorizedPersonWithoutLists
    {
        /// <summary>
        /// Authorized person ID
        /// </summary>
        [Key]
        public Guid authorizedPersonId { get; set; }
        /// <summary>
        /// Authorized person's name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Authorized person's surname
        /// </summary>
        public string surname { get; set; }
        /// <summary>
        /// Authorized person's jmbg
        /// </summary>
        public string jmbg { get; set; }
    }
}
