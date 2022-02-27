using Application.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly LicitationApplicationContext context;
        private readonly IMapper mapper;

        public ApplicationRepository(LicitationApplicationContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public LicitationApplicationConfirmation CreateApplication(LicitationApplication application)
        {
            var createdEntity = context.Add(application);
            return mapper.Map<LicitationApplicationConfirmation>(createdEntity.Entity);
        }

        public void DeleteApplication(Guid applicationId)
        {
            var application = GetApplicationById(applicationId);
            context.Remove(application);
        }

        public LicitationApplication GetApplicationById(Guid applicationId)
        {
            return context.Applications.FirstOrDefault(e => e.applicationId == applicationId);
        }

        public List<LicitationApplication> GetApplications()
        {
            return context.Applications.ToList();
        }
                                                                    
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateApplication(LicitationApplication application)
        {
            // Entity framework can do it by itself
        }
    }
}
