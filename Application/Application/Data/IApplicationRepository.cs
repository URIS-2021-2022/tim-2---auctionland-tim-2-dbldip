using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Data
{
    public interface IApplicationRepository
    {
        List<LicitationApplication> GetApplications();

        LicitationApplication GetApplicationById(Guid applicationId);

        LicitationApplicationConfirmation CreateApplication(LicitationApplication application);

        void UpdateApplication(LicitationApplication application);

        void DeleteApplication(Guid applicationId);

        bool SaveChanges();

    }
}
