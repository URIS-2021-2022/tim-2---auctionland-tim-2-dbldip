using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Models
{
    public class AuthorizedPersonUpdateDto : AuthorizedPersonCreationDto
    {
        /// <summary>
        /// Authorized person ID
        /// </summary>
        public Guid authorizedPersonId { get; set; }
    }
}
