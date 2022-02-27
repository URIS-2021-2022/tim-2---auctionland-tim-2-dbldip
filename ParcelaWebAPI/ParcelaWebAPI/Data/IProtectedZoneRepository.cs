using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public interface IProtectedZoneRepository
    {
        List<ProtectedZone> GetProtectedZones(int level = 0);
        ProtectedZone GetProtectedZoneById(Guid protectedZoneId);
        bool SaveChanges();
    }
}
