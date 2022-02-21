using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Data
{
    public interface ICommissionRepository
    {
        List<CommissionWithLists> GetCommissions(string presidentId = null);
            
        CommissionWithLists GetCommissionById(Guid commissionId);

        CommissionConfirmation CreateCommission(CommissionCreation commission);

        void UpdateCommission(CommissionWithLists commission);

        void DeleteCommission(Guid commissionId);

        bool SaveChanges();
    }
}
