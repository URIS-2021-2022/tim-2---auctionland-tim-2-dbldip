using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Data
{
    public interface IPersonRepository
    {
        List<Person> GetPersons(string name = null, string surname = null, string role = null);

        Person GetPersonById(Guid personId);

        PersonConfirmation CreatePerson(Person person);

        void UpdatePerson(Person person);

        void DeletePerson(Guid personId);

        bool SaveChanges();
    }
}
