using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IPriorityRepository
    {
        List<Priority> GetPriorities();
        Priority GetPriorityById(Guid priorityId);
        bool SaveChanges();
    }
}
