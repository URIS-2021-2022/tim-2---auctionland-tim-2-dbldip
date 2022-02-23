using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Entities
{
    public class ParcelUserConfirmation
    {
        /// <summary>
        /// Parcel user ID
        /// </summary>
        public Guid parcelUserId { get; set; }
        /// <summary>
        /// Parcel user's name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Parcel user's surname
        /// </summary>
        public string surname { get; set; }
        /// <summary>
        /// Parcel user's jmbg
        /// </summary>
        public string jmbg { get; set; }
        /// <summary>
        /// Parcel user's address
        /// </summary>
        public string address { get; set; }
    }
}
