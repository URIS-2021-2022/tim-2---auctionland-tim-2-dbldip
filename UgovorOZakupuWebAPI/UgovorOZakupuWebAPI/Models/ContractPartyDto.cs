﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    public class ContractPartyDto
    {
        public Guid ContractPartyId { get; set; }

        public string PartyName { get; set; }

        public string PartySurname { get; set; }

        public string PartyJMBG { get; set; }
    }
}
