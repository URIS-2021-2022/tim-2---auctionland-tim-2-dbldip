using AppUserWebAPI.Entities;
using AppUserWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppUserWebAPI.Data
{
    public class AppUserRepository : IAppUserRepository
    {

        private readonly AppUserContext context;
        private readonly IMapper mapper;

        public AppUserRepository(AppUserContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public AppUserConfirmation CreateAppUser(AppUser user)
        {
            var createdEntity = context.Add(user);
            return mapper.Map<AppUserConfirmation>(createdEntity.Entity);

        }

        public void DeleteAppUser(Guid appUserId)
        {
            var user = GetAppUser(appUserId);
            context.Remove(user);
        }

        public AppUser GetAppUser(Guid appUserId)
        {
            return context.AppUsers.FirstOrDefault(e => e.appUserId == appUserId);
        }

        public AppUser GetAppUserByUsername(string username)
        {
            return context.AppUsers.FirstOrDefault(e => e.appUserName == username);
        }

        public List<AppUser> GetAppUsers(string firstName = null, string lastName = null, string typeOfUser = null)
        {
            return context.AppUsers.Where(e => (firstName == null || e.appUserName == firstName) 
                                                && (lastName == null || e.appUserLastName == lastName) 
                                                && (typeOfUser == null || e.typeOfUser == typeOfUser))
                .ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateAppUser(AppUser user)
        {
        }

        public bool validateUserData(AppUser user)
        {
            return GetAppUserByUsername(user.appUserName) == null;
        }

    }
}
