using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public interface IGuaranteeTypeRepository
    {
        List<GuaranteeType> GetGuaranteeTypes();
        GuaranteeType GetGuaranteeTypeById(Guid guaranteeTypeId);
        GuaranteeTypeConfirmation CreateGuaranteeType(GuaranteeType guaranteeType);
        void UpdateGuaranteeType(GuaranteeType guaranteeType);
        void DeleteGuaranteeType(Guid guaranteeTypeId);
        bool SaveChanges();
    }
}
