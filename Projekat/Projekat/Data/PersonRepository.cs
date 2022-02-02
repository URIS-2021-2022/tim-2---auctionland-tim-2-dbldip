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
        private readonly IMapper mapper;
        private readonly CommissionContext context;

        public PersonRepository(IMapper mapper, CommissionContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        
        public PersonConfirmation CreatePerson(Person person)
        {
            var createdEntity = context.Add(person);
            return mapper.Map<PersonConfirmation>(createdEntity.Entity);
        }

        public void DeletePerson(Guid personId)
        {
            var person = GetPersonById(personId);
            context.Remove(person);
        }

        public Person GetPersonById(Guid personId)
        {
            return context.Persons.FirstOrDefault(e => e.PersonId == personId) ;
        }

        public List<Person> GetPersons(string name = null, string surname = null, string role = null)
        {
            return context.Persons.Where(e => (name == null || e.Name == name && 
                                               surname == null || e.Surname == surname &&
                                               role == null || e.Role == role)).ToList();
        }

        public void UpdatePerson(Person person)
        {

        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}