using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelUserDtos
{
    public class ParcelUserCreationDto
    {


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
