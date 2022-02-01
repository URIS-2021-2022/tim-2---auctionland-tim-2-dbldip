using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Data
{
    public interface ICommissionRepository
    {
        List<Commission> GetCommissions(string presidentId = null);
            
        Commission GetCommissionById(Guid commissionId);

        CommissionConfirmation CreateCommission(Commission commission);

        CommissionConfirmation UpdateCommission(Commission commission);

        void DeleteCommission(Guid commissionId);
    }
}
