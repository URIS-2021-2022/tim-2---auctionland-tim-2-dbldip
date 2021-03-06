using KupacWebApi.Entities.OtherAgregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class AuthorizedPersonCreation
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
        /// List of IDs - Buyer 
        /// </summary>
        public List<Guid> buyerIds { get; set; }
        /// <summary>
        /// List of table numbers
        /// </summary>
        public List<int> tableNumber { get; set; }
        /// <summary>
        /// Address ID
        /// </summary>
        public Guid addressId { get; set; }
        /// <summary>
        /// Country ID
        /// </summary>
        public Guid countryId { get; set; }
    }
}
