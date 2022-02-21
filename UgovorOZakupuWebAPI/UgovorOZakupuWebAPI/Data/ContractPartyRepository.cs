using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public class ContractPartyRepository : IContractPartyRepository
    {
        private readonly LeaseAgreementContext context;
        private readonly IMapper mapper;

        public ContractPartyRepository(LeaseAgreementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ContractPartyConfirmation CreateContractParty(ContractParty contractParty)
        {
            var createdEntity = context.Add(contractParty);
            return mapper.Map<ContractPartyConfirmation>(createdEntity.Entity);
        }

        public void DeleteContractParty(Guid contractPartyId)
        {
            var contractParty = GetContractPartyById(contractPartyId);
            context.Remove(contractParty);
        }

        public List<ContractParty> GetContractParties()
        {
            return context.ContractParties.ToList();
        }

        public ContractParty GetContractPartyById(Guid contractPartyId)
        {
            return context.ContractParties.FirstOrDefault(e => e.ContractPartyId == contractPartyId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateContractParty(ContractParty contractParty)
        {
            
        }
    }
}
