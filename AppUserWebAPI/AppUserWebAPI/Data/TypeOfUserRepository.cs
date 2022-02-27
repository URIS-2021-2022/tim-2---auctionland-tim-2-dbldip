using AppUserWebAPI.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Data
{
    public class TypeOfUserRepository : ITypeOfUserRepository
    {

        private readonly AppUserContext context;

        public TypeOfUserRepository(AppUserContext context)
        {
            this.context = context;
        }

        public TypeOfUser GetTypeOfUserById(Guid typeOfUserId)
        {
            return context.Types.FirstOrDefault(e => e.typeOfUserId == typeOfUserId);
        }

        public List<TypeOfUser> GetTypesOfUser()
        {
            return context.Types.ToList();
        }

    }
}
