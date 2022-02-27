using KupacWebApi.Entities.ConnectionClasses;
using KupacWebApi.Entities.OtherAgregates;
using KupacWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class AuthorizedPerson
    {
        /// <summary>
        /// AuthorizedPerson ID
        /// </summary>
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
        /// <summary>
        /// List of IDs - Buyer and Authorized person
        /// </summary>
        public List<BuyerAuthorizedPersonConnection> buyers { get; set; }
        /// <summary>
        /// List of table numbers
        /// </summary>
        public List<int> tableNumber { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public Address address { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public Country country { get; set; }
        /// <summary>
        /// Delete check property
        /// </summary>
        public bool isDelete { get; set; }

    }
}
