﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class AuthorizedPersonUpdate : AuthorizedPersonCreation
    {
        public Guid authorizedPersonId { get; set; }
    }
}
