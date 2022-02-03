using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    interface IProtectedZoneRepository
    {
        List<ProtectedZone> GetProtectedZones(int level = 0);
        ProtectedZone GetProtectedZoneById(Guid protectedZoneId);
        void UpdateProtectedZone(ProtectedZone protectedZone);
        bool SaveChanges();
    }
}
