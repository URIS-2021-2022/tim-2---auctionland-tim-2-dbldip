using AppUserWebAPI.Entities;
using AppUserWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Data
{
    public interface IAppUserRepository
    {
        List<AppUser> GetAppUsers(string firstName = null, string lastName = null, string typeOfUser = null);
        AppUser GetAppUser(Guid appUserId);
        AppUser GetAppUserByUsername(string username);
        AppUserConfirmation CreateAppUser(AppUser user);
        void UpdateAppUser(AppUser user);
        void DeleteAppUser(Guid appUserId);
        bool SaveChanges();
        bool validateUserData(AppUser user);
    }
}
