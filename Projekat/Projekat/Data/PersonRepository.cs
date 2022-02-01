using AutoMapper;
using Projekat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Data
{
    public class PersonRepository : IPersonRepository
    {
        public static List<Person> Persons { get; set; } = new List<Person>();
        private readonly IMapper mapper;

        public PersonRepository(IMapper mapper)
        {
            FillData();
            this.mapper = mapper;
        }

        void FillData()
        {
           Persons.AddRange(new List<Person>
            {
                new Person
                {
                    PersonId = Guid.Parse("7845cc32-71e2-4336-bb3c-11e6b3699673"),
                    Name = "Nikola",
                    Surname = "Bikar",
                    Role = "President"
                },
                new Person
                {
                    PersonId = Guid.Parse("4244b81e-2a10-40f7-9102-e1b34192eae3"),
                    Name = "Marko",
                    Surname = "Markovic",
                    Role = "Ucesnik"
                },
                new Person
                {
                    PersonId = Guid.Parse("7d60cc93-0ba3-475b-a36b-f203ebb3281b"),
                    Name = "Jovan",
                    Surname = "Jovanovic",
                    Role = "Ucesnik"
                },
            });
        }
        public PersonConfirmation CreatePerson(Person person)
        {
            person.PersonId = Guid.NewGuid();
            Persons.Add(person);
            Person person1 = GetPersonById(person.PersonId);
            return new PersonConfirmation
            {
                PersonId = person1.PersonId,
                Name = person1.Name,
                Surname = person1.Surname,
                Role = person1.Role
            };   
        }

        public void DeletePerson(Guid personId)
        {
            Persons.Remove(Persons.FirstOrDefault(e => e.PersonId == personId));
        }

        public Person GetPersonById(Guid personId)
        {
            return Persons.FirstOrDefault(e => e.PersonId == personId);
        }

        public List<Person> GetPersons(string name = null, string surname = null, string role = null)
        {
            return (from e in Persons
                    where string.IsNullOrEmpty(name) || e.Name == name &&
                          string.IsNullOrEmpty(surname) || e.Surname == surname &&
                          string.IsNullOrEmpty(role) || e.Role == role
                    select e).ToList();
        }

        public PersonConfirmation UpdatePerson(Person person)
        {
            Person personEntity = GetPersonById(person.PersonId);

            personEntity.PersonId = person.PersonId;
            personEntity.Name = person.Name;
            personEntity.Surname = person.Surname;
            personEntity.Role = person.Role;

            return new PersonConfirmation
            {
                PersonId = personEntity.PersonId,
                Name = personEntity.Name,
                Surname = personEntity.Surname,
                Role = personEntity.Role
            };
        }
    }
}
