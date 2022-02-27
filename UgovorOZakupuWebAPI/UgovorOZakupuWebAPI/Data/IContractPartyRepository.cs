using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public interface IContractPartyRepository
    {
        List<ContractParty> GetContractParties();
        ContractParty GetContractPartyById(Guid contractPartyId);
        ContractPartyConfirmation CreateContractParty(ContractParty contractParty);
        void UpdateContractParty(ContractParty contractParty);
        void DeleteContractParty(Guid contractPartyId);
        bool SaveChanges();
    }
}
