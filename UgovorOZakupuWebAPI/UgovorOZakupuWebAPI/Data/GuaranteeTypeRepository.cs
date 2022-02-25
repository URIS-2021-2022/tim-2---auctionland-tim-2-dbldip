using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public class GuaranteeTypeRepository : IGuaranteeTypeRepository
    {
        private readonly LeaseAgreementContext context;

        public GuaranteeTypeRepository(LeaseAgreementContext context)
        {
            this.context = context;
        }

        public List<GuaranteeType> GetGuaranteeTypes()
        {
            return context.GuaranteeTypes.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
