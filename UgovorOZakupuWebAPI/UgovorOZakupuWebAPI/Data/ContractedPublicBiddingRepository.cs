using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public class ContractedPublicBiddingRepository : IContractedPublicBiddingRepository
    {
        private readonly LeaseAgreementContext context;
        private readonly IMapper mapper;
        public ContractedPublicBiddingRepository(LeaseAgreementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ContractedPublicBiddingConfirmation CreateContractedPublicBidding(ContractedPublicBidding contractedPublicBidding)
        {
            var createdEntity = context.Add(contractedPublicBidding);
            return mapper.Map<ContractedPublicBiddingConfirmation>(createdEntity.Entity);
        }

        public void DeleteContractedPublicBidding(Guid contractedPublicBiddingId)
        {
            var contractedPublicBidding = GetContractedPublicBiddingById(contractedPublicBiddingId);
            context.Remove(contractedPublicBidding);
        }

        public ContractedPublicBidding GetContractedPublicBiddingById(Guid contractedPublicBiddingId)
        {
            return context.ContractedPublicBiddings.FirstOrDefault(e => e.ContractedPublicBiddingId == contractedPublicBiddingId);
        }

        public List<ContractedPublicBidding> GetContractedPublicBiddings()
        {
            var contractedPublicBiddings = this.context.ContractedPublicBiddings.ToList();
            if (contractedPublicBiddings == null || contractedPublicBiddings.Count == 0)
                return(List<ContractedPublicBidding>)Enumerable.Empty<Document>();
            return contractedPublicBiddings;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateContractedPublicBidding(ContractedPublicBidding contractedPublicBidding)
        {
            //updates automatically
        }
    }
}
