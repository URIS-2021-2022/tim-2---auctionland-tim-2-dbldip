using AutoMapper;
using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Data
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

        public CommissionConfirmation CreateCommission(CommissionCreation commission)
        {
            var mappedEntity = mapper.Map<Commission>(commission);
            var createdEntity = context.Add(mappedEntity);
            foreach(var el in commission.Members)
            {
                var temp = new Members();
                temp.CommissionId = commission.CommissionId;
                temp.PersonId = el;
                context.Add(temp);
            }
            return mapper.Map<CommissionConfirmation>(createdEntity.Entity);
        }

        public void DeleteCommission(Guid commissionId)
        {
            var commissionToDelete = GetCommissionById(commissionId);
            commissionToDelete.IsDelete = true;
            UpdateCommission(commissionToDelete);
        }

        public CommissionWithLists GetCommissionById(Guid commissionId)
        {
            var commission = this.context.Commissions.FirstOrDefault(e => e.CommissionId == commissionId);
            if (commission == null)
                return null;
            var returnCommission = mapper.Map<CommissionWithLists>(commission);
            returnCommission.President = context.Persons.FirstOrDefault(e => e.PersonId == commission.PresidentId);
            returnCommission.Members = context.Members.Where(e => e.CommissionId == commission.CommissionId).ToList();
            return returnCommission;
        }

        public List<CommissionWithLists> GetCommissions(string presidentId = null)
        {
            var commissions = this.context.Commissions.ToList();
            if (commissions == null || commissions.Count == 0)
                return null;
            List<CommissionWithLists> returnList = mapper.Map<List<CommissionWithLists>>(commissions);
            foreach(var el in returnList)
            {
                el.President = context.Persons.FirstOrDefault(e => e.PersonId == el.PresidentId);
                el.Members = context.Members.Where(e => e.CommissionId == el.CommissionId).ToList();  
            }
            return returnList;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateCommission(CommissionWithLists commission)
        {
        }
    }
}
