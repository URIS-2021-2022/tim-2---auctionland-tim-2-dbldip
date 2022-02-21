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
        private readonly IMapper mapper;

        public GuaranteeTypeRepository(LeaseAgreementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public GuaranteeTypeConfirmation CreateGuaranteeType(GuaranteeType guaranteeType)
        {
            var createdEntity = context.Add(guaranteeType);
            return mapper.Map<GuaranteeTypeConfirmation>(createdEntity.Entity);
        }

        public void DeleteGuaranteeType(Guid guaranteeTypeId)
        {
            var guaranteeType = GetGuaranteeTypeById(guaranteeTypeId);
            context.Remove(guaranteeType);
        }

        public GuaranteeType GetGuaranteeTypeById(Guid guaranteeTypeId)
        {
            return context.GuaranteeTypes.FirstOrDefault(e => e.GuaranteeTypeId == guaranteeTypeId);
        }

        public List<GuaranteeType> GetGuaranteeTypes()
        {
            return context.GuaranteeTypes;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateGuaranteeType(GuaranteeType guaranteeType)
        {
            
        }
    }
}
