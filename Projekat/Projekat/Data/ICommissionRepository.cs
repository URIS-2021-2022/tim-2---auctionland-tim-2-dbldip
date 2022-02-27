using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Data
{
    public interface ICommissionRepository
    {
        List<CommissionsFilledDto> GetCommissions(string presidentId = null);
            
        Commission GetCommissionById(Guid commissionId);

        CommissionConfirmation CreateCommission(Commission commission);

        void UpdateCommission(CommissionWithLists commission);

        void DeleteCommission(Guid commissionId);

        void UpdateMembers(List<Members> members, Guid commissionId);

        bool SaveChanges();
    }
}
