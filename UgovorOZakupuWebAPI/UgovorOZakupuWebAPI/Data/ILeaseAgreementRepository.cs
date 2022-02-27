using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public interface ILeaseAgreementRepository
    {
        List<LeaseAgreementWithLists> GetLeaseAgreements(string serialNumber);

        LeaseAgreement GetLeaseAgreementById(Guid leaseAgreementId);

        LeaseAgreementConfirmation CreateLeaseAgreement(LeaseAgreement leaseAgreement);

        void UpdateLeaseAgreement(LeaseAgreementWithLists leaseAgreementWithLists);

        void UpdateMaturityDeadlines(List<MaturityDeadline> maturityDeadlines, Guid leaseAgreementId);

        void DeleteLeaseAgreement(Guid leaseAgreementId);

        bool SaveChanges();
    }
}
