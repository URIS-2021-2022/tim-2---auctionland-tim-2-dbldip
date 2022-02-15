using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public interface IParcelPartRepository
    {
        List<ParcelPart> GetParcelParts(string partSurfaceArea = null, int partParcelNumber = 0);
        ParcelPart GetParcelPartById(Guid parcelPartId);
        ParcelPartConfirmation CreateParcelPart(ParcelPart parcelPart);
        void UpdateParcelPart(ParcelPart parcelPart);
        void DeleteParcelPart(Guid parcelPartId);
        bool SaveChanges();
    }
}
