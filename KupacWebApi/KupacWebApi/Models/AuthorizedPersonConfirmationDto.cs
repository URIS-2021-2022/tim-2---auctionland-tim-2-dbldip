using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Models
{
    public class AuthorizedPersonConfirmationDto
    {
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
        /// <summary>
        /// List of table numbers
        /// </summary>
        public List<int> tableNumber { get; set; }

    }
}
