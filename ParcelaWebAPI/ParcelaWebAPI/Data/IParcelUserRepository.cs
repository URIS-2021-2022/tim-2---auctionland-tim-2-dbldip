using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public interface IParcelUserRepository
    {
        List<ParcelUser> GetParcelUsers(string name = null, string surname = null, string jmbg = null);
        ParcelUser GetParcelUserById(Guid parcelUserId);
        ParcelUserConfirmation CreateParcelUser(ParcelUser parcelUser);
        void UpdateParcelUser(ParcelUser parcelUser);
        void DeleteParcelUser(Guid parcelUserId);
        bool SaveChanges();
    }
}
