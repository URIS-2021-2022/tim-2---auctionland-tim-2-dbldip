using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Models
{
    public class AuthorizedPersonUpdateDto : AuthorizedPersonCreationDto
    {
        public Guid authorizedPersonId { get; set; }
    }
}
