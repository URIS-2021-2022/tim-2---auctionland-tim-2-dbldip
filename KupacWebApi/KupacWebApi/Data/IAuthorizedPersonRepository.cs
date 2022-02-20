using KupacWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Data
{
    public interface IAuthorizedPersonRepository
    {
        AuthorizedPersonConfirmation CreateAuthorizedPerson(AuthorizedPersonCreation authorizedPerson);
        List<AuthorizedPerson> GetAuthorizedPersons();
        AuthorizedPerson GetAuthorizedPerson(Guid authorizedPersonId);
        void UpdateAuthorizedPerson(AuthorizedPerson authorizedPerson);
        void DeleteAuthorizedPerson(Guid authorizedPersonId);
        bool SaveChanges();
    }
}
