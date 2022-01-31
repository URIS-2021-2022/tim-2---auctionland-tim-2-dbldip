using AppUserWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Data
{
    public  interface ITypeOfUserRepository
    {
        List<TypeOfUser> GetTypesOfUser();
        TypeOfUser GetTypeOfUserById(Guid typeOfUserId);
        void UpdateTypeOfUser(TypeOfUser typeOfUser);
        bool SaveChanges();
    }
}
