using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Data
{
    public class CommissionRepository : ICommissionRepository
    {
        private List<Commission> Commissions { get; set; } = new List<Commission>();

        public CommissionRepository()
        {
            FillData();
        }

        public void FillData()
        {
            Commissions.AddRange(new List<Commission>
            {
                new Commission
                {
                    CommissionId = Guid.Parse("aa5ce9dc-1534-472d-8d9b-63cc87ca5a39"),
                    President = new Person
                    { 
                        PersonId = Guid.Parse("7845cc32-71e2-4336-bb3c-11e6b3699673"),
                        Name = "Nikola",
                        Surname = "Bikar",
                        Role = "President" 
                    },
                    Members = new List<Person>
                    {
                        new Person
                        {
                            PersonId = Guid.Parse("4244b81e-2a10-40f7-9102-e1b34192eae3"),
                            Name = "Marko",
                            Surname = "Markovic",
                            Role = "Ucesnik"
                        },
                        new Person
                        {
                            PersonId = Guid.Parse("7d60cc93-0ba3-475b-a36b-f203ebb3281b"),
                            Name = "Jovan",
                            Surname = "Jovanovic",
                            Role = "Ucesnik"
                        }
                    }
                }
            });
        }
        public CommissionConfirmation CreateCommission(Commission commission)
        {
            commission.CommissionId = Guid.NewGuid();
            Commissions.Add(commission);
            return new CommissionConfirmation
            {
                CommissionId = commission.CommissionId,
                Members = commission.Members,
                President = commission.President
            };
        }

        public void DeleteCommission(Guid commissionId)
        {
            Commissions.Remove(Commissions.FirstOrDefault(e => e.CommissionId == commissionId));
        }

        public Commission GetCommissionById(Guid commissionId)
        {
            return Commissions.FirstOrDefault(e => e.CommissionId == commissionId);
        }

        public List<Commission> GetCommissions(string presidentId = null)
        {
            return (from e in Commissions
                    where string.IsNullOrEmpty(presidentId) || e.President.PersonId.ToString() == presidentId
                    select e).ToList();
        }

        public CommissionConfirmation UpdateCommission(Commission commission)
        {
            Commission commissionEntity = GetCommissionById(commission.CommissionId);

            commissionEntity.CommissionId = commission.CommissionId;
            commissionEntity.President = commission.President;
            commissionEntity.Members = commission.Members;
        
            return new CommissionConfirmation
            {
                CommissionId = commissionEntity.CommissionId,
                President = commissionEntity.President,
                Members = commissionEntity.Members
            };
        }
    }
}
