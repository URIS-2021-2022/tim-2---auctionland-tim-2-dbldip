using AutoMapper;
using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public class ProtectedZoneRepository : IProtectedZoneRepository
    {

        private readonly ParcelContext context;
        private readonly IMapper mapper;

        public ProtectedZoneRepository(ParcelContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ProtectedZone GetProtectedZoneById(Guid protectedZoneId)
        {
            return context.ProtectedZones.FirstOrDefault(e => e.protectedZoneId == protectedZoneId);
        }

        public List<ProtectedZone> GetProtectedZones(int level = 0)
        {
            return context.ProtectedZones.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

       
    }
}
