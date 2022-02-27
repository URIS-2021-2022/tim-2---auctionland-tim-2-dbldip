using AppUserWebAPI.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(user.appUserPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            user.appUserPassword = savedPasswordHash;
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
            return context.AppUsers.FirstOrDefault(e => e.appUserUsername == username);
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

            //EF implements this method

        }

        public bool validateUserData(AppUser user)
        {
            return GetAppUserByUsername(user.appUserUsername) == null;
        }

    }
}
