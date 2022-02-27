using Application.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly LicitationApplicationContext context;

        public PriorityRepository(LicitationApplicationContext context)
        {
            this.context = context;

        }

        public List<Priority> GetPriorities()
        {
            return context.Priorities.ToList();
        }

        public Priority GetPriorityById(Guid priorityId)
        {
            return context.Priorities.FirstOrDefault(e => e.priorityID == priorityId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
 
    }
}
