using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public interface IParcelRepository
    {

        List<Parcel> GetParcels(string surfaceArea = null, int parcelNumber = 0);
        Parcel GetParcelById(Guid parcelId);
        ParcelConfirmation CreateParcel(Parcel parcel);
        void UpdateParcel(Parcel parcel);
        void DeleteParcel(Guid parcelId);
        bool SaveChanges();
    }
}
