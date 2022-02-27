using AutoMapper;
using CommissionWebAPI.Entities;
using CommissionWebAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public CommissionConfirmation CreateCommission(Commission commission)
        {
            var createdEntity = context.Add(commission);
            foreach(var el in commission.Members)
            {
                var temp = new Members();
                temp.CommissionId = commission.CommissionId;
                temp.PersonId = el.PersonId;
                context.Add(temp);
            }
            return mapper.Map<CommissionConfirmation>(createdEntity.Entity);
        }

        public void DeleteCommission(Guid commissionId)
        {
            var commission = context.Commissions.FirstOrDefault(e => e.CommissionId == commissionId);
            context.Remove(commission);
        }

        public Commission GetCommissionById(Guid commissionId)
        {
            var commission = this.context.Commissions.FirstOrDefault(e => e.CommissionId == commissionId);
            var returnCommission = mapper.Map<Commission>(commission);
            if (returnCommission == null)
            {
                return null;
            }
            returnCommission.President = context.Persons.FirstOrDefault(e => e.PersonId == commission.PresidentId);
            returnCommission.Members = context.Members.Where(e => e.CommissionId == commission.CommissionId).ToList();
            return returnCommission;
        }

        public List<CommissionsFilledDto> GetCommissions(string presidentId = null)
        {
            var commissions = this.context.Commissions.ToList();
            foreach(var el in commissions)
            {
                el.President = context.Persons.FirstOrDefault(e => e.PersonId == el.PresidentId);
                el.Members = context.Members.Where(e => e.CommissionId == el.CommissionId).ToList();  
            }
            List<CommissionsFilledDto> commissionsFilled = new List<CommissionsFilledDto>();
            foreach(var el in commissions)
            {
                CommissionsFilledDto temp = new CommissionsFilledDto();      
                temp.CommissionId = el.CommissionId;
                temp.President = el.President;
                if (el.Members != null)
                {
                    foreach (var el1 in el.Members)
                    {
                        Person temp1;
                        temp1 = context.Persons.FirstOrDefault(e => e.PersonId == el1.PersonId);
                        temp.Members.Add(temp1);
                    }
                }  
                commissionsFilled.Add(temp);
            }
            return commissionsFilled;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateMembers(List<Members> members, Guid commissionId)
        {
            foreach(var el in context.Members.Where(e => e.CommissionId == commissionId))
            {
                context.Remove(el);
            }
            foreach(var el in members)
            {
                var temp = new Members();
                temp.CommissionId = el.CommissionId;
                temp.PersonId = el.PersonId;
                context.Add(temp);
            }
        }

        public void UpdateCommission(CommissionWithLists commission)
        {
            //Updates automatically
        }
    }
}
