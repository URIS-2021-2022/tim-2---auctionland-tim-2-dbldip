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

        public LeaseAgreementConfirmation CreateLeaseAgreement(LeaseAgreementCreation leaseAgreement)
        {
            throw new NotImplementedException();
        }

        public void DeleteLeaseAgreement(Guid leaseAgreementId)
        {
            throw new NotImplementedException();
        }

        public LeaseAgreementWithLists GetLeaseAgreementById(Guid leaseAgreementId)
        {
            throw new NotImplementedException();
        }

        public List<LeaseAgreementWithLists> GetLeaseAgreements()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateLeaseAgreement(LeaseAgreementWithLists leaseAgreement)
        {
            throw new NotImplementedException();
        }
    }
}
