using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    interface IParcelUserRepository
    {
        List<ParcelUser> GetParcelUsers(string name = null, string surname = null, string jmbg = null);
        ParcelUser GetParcelUserById(Guid parcelUserId);
        ParcelUser CreateParcelUser(ParcelUser parcelUser);
        void UpdateParcelUser(ParcelUser parcelUser);
        void DeleteParcelUser(Guid parcelUserId);
        bool SaveChanges();
    }
}
