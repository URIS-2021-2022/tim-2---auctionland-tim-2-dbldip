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

        LeaseAgreementWithLists GetLeaseAgreementById(Guid leaseAgreementId);

        LeaseAgreementConfirmation CreateLeaseAgreement(LeaseAgreement leaseAgreement);

        void UpdateLeaseAgreement(LeaseAgreementWithLists leaseAgreement);

        void DeleteLeaseAgreement(Guid leaseAgreementId);

        bool SaveChanges();
    }
}
