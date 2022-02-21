using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public interface ILeaseAgreementRepository
    {
        List<LeaseAgreementWithLists> GetLeaseAgreements();

        LeaseAgreementWithLists GetLeaseAgreementById(Guid leaseAgreementId);

        LeaseAgreementConfirmation CreateLeaseAgreement(LeaseAgreementCreation leaseAgreement);

        void UpdateLeaseAgreement(LeaseAgreementWithLists leaseAgreement);

        void DeleteLeaseAgreement(Guid leaseAgreementId);

        bool SaveChanges();
    }
}
