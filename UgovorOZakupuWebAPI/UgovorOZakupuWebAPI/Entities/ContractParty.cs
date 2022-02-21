using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class ContractParty
    {
        public Guid ContractPartyId { get; set; }

        public string PartyName { get; set; }

        public string PartySurname { get; set; }

        public string PartyJMBG { get; set; }

    }
}
