using AutoMapper;
using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public class ParcelUserRepository : IParcelUserRepository
    {

            private readonly ParcelContext context;
            private readonly IMapper mapper;

            public ParcelUserRepository(ParcelContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public ParcelUser CreateParcelUser(ParcelUser parcelUser)
        {
            var createdEntity = context.Add(parcelUser);
            return mapper.Map<ParcelUser>(createdEntity.Entity);
        }

        public void DeleteParcelUser(Guid parcelUserId)
        {
            var parcelUser = GetParcelUserById(parcelUserId);
            context.Remove(parcelUser);
        }

        public ParcelUser GetParcelUserById(Guid parcelUserId)
        {
            return context.ParcelUsers.FirstOrDefault(e => e.parcelUserId == parcelUserId);
        }

        public List<ParcelUser> GetParcelUsers(string name = null, string surname = null, string jmbg = null)
        {
            return context.ParcelUsers.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateParcelUser(ParcelUser parcelUser)
        {
            throw new NotImplementedException();
        }
    }
}
