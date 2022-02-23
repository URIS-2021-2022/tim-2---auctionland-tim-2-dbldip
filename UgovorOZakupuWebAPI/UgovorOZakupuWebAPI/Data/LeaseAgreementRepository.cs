using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public class LeaseAgreementRepository : ILeaseAgreementRepository
    {
        private readonly IMapper mapper;
        private readonly LeaseAgreementContext context;

        public LeaseAgreementRepository(IMapper mapper, LeaseAgreementContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public LeaseAgreementConfirmation CreateLeaseAgreement(LeaseAgreement leaseAgreement)
        {
            var createdEntity = context.Add(leaseAgreement);
            foreach(var el in leaseAgreement.MaturityDeadlines)
            {
                var temp = new MaturityDeadline();
                temp.MaturityDeadlineId = el.MaturityDeadlineId;
                temp.LeaseAgreementId = leaseAgreement.LeaseAgreementId;
                temp.Deadline = el.Deadline;
                context.Add(temp);
            }
            return mapper.Map<LeaseAgreementConfirmation>(createdEntity.Entity);
        }

        public void DeleteLeaseAgreement(Guid leaseAgreementId)
        {
            var leaseAgreementToDelete = GetLeaseAgreementById(leaseAgreementId);
            leaseAgreementToDelete.IsDelete = true;
            UpdateLeaseAgreement(leaseAgreementToDelete);
        }

        public LeaseAgreementWithLists GetLeaseAgreementById(Guid leaseAgreementId)
        {
            var leaseAgreement = this.context.LeaseAgreements.FirstOrDefault(e => e.LeaseAgreementId == leaseAgreementId);
            if (leaseAgreement == null)
                return null;
            var returnLeaseAgreement = mapper.Map<LeaseAgreementWithLists>(leaseAgreement);
            returnLeaseAgreement.MaturityDeadlines = context.MaturityDeadlines.Where(e => e.LeaseAgreementId == leaseAgreementId).ToList();
            returnLeaseAgreement.ContractedPublicBidding = context.ContractedPublicBiddings.FirstOrDefault(e => e.ContractedPublicBiddingId == leaseAgreement.ContractedPublicBiddingId);
            returnLeaseAgreement.ContractParty = context.ContractParties.FirstOrDefault(e => e.ContractPartyId == leaseAgreement.ContractPartyId);
            returnLeaseAgreement.GuaranteeType = context.GuaranteeTypes.FirstOrDefault(e => e.GuaranteeTypeId == leaseAgreement.GuaranteeTypeId);
            returnLeaseAgreement.Decision = context.Documents.FirstOrDefault(e => e.DocumentId == leaseAgreement.DecisionId);
            return returnLeaseAgreement;
        }

        public List<LeaseAgreementWithLists> GetLeaseAgreements(string serialNumber)
        {
            var leaseAgreements = this.context.LeaseAgreements.ToList();
            if (leaseAgreements == null || leaseAgreements.Count == 0)
                return null;
            List<LeaseAgreementWithLists> returnList = mapper.Map<List<LeaseAgreementWithLists>>(leaseAgreements);
            foreach(var el in returnList)
            {
                el.MaturityDeadlines = context.MaturityDeadlines.Where(e => e.LeaseAgreementId == el.LeaseAgreementId).ToList();
                el.ContractedPublicBidding = context.ContractedPublicBiddings.FirstOrDefault(e => e.ContractedPublicBiddingId == el.ContractedPublicBiddingId);
                el.ContractParty = context.ContractParties.FirstOrDefault(e => e.ContractPartyId == el.ContractPartyId);
                el.GuaranteeType = context.GuaranteeTypes.FirstOrDefault(e => e.GuaranteeTypeId == el.GuaranteeTypeId);
                el.Decision = context.Documents.FirstOrDefault(e => e.DocumentId == el.DecisionId);
            }
            return returnList;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateLeaseAgreement(LeaseAgreementWithLists leaseAgreement)
        {
        
        }
    }
}
