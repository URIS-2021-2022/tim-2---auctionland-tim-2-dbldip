using KupacWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Data
{
    public class AuthorizedPersonRepository : IAuthorizedPersonRepository
    {
        public AuthorizedPersonConfirmation CreateAuthorizedPerson(AuthorizedPersonCreation authorizedPerson)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthorizedPerson(Guid authorizedPersonId)
        {
            throw new NotImplementedException();
        }

        public AuthorizedPerson GetAuthorizedPerson(Guid authorizedPersonId)
        {
            throw new NotImplementedException();
        }

        public List<AuthorizedPerson> GetAuthorizedPersons()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthorizedPerson(AuthorizedPerson authorizedPerson)
        {
            throw new NotImplementedException();
        }
    }
}
