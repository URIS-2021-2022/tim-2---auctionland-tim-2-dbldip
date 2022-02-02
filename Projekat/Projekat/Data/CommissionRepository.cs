using AutoMapper;
using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Data
{
    public class CommissionRepository : ICommissionRepository
    {
        private readonly CommissionContext context;
        private readonly IMapper mapper;

        public CommissionRepository(IMapper mapper, CommissionContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public CommissionConfirmation CreateCommission(Commission commission)
        {
            var createdEntity = context.Add(commission);
            return mapper.Map<CommissionConfirmation>(createdEntity.Entity);
        }

        public void DeleteCommission(Guid commissionId)
        {
            var commission = GetCommissionById(commissionId);
            context.Remove(commission);
        }

        public Commission GetCommissionById(Guid commissionId)
        {
            return context.Commissions.FirstOrDefault(e => e.CommissionId == commissionId);
        }

        public List<Commission> GetCommissions(string presidentId = null)
        {
            return context.Commissions.Where(e => presidentId == null || e.President.PersonId == Guid.Parse(presidentId)).ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateCommission(Commission commission)
        {
        }

    }
}
