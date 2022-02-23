using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Entities.ConnectionClasses;
using KupacWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Data
{
    public class AuthorizedPersonRepository : IAuthorizedPersonRepository
    {
        private readonly BuyerContext context;
        private readonly IMapper mapper;
        public AuthorizedPersonRepository(BuyerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public AuthorizedPersonConfirmation CreateAuthorizedPerson(AuthorizedPersonCreation authorizedPerson)
        {
            var mappedEntity = mapper.Map<AuthorizedPersonWithoutLists>(authorizedPerson);
            var createdEntity = context.Add(mappedEntity);


            foreach (var el in authorizedPerson.buyerIds)
            {
                //avoiding double combination of keys
                var help = this.context.BuyerAuthorizedPeople.FirstOrDefault(e => (e.buyerId == el && e.authorizedPersonId == createdEntity.Entity.authorizedPersonId));
                if(help != null)
                {
                    return null;
                }
                var temp = new BuyerAuthorizedPersonConnection();
                temp.buyerId = el;
                temp.authorizedPersonId = createdEntity.Entity.authorizedPersonId;
                context.Add(temp);
            }

            return mapper.Map<AuthorizedPersonConfirmation>(createdEntity.Entity);
        }

        public AuthorizedPerson GetAuthorizedPerson(Guid authorizedPersonId)
        {
            var authorizedPerson = this.context.AuthorizedPeople.FirstOrDefault(e => e.authorizedPersonId == authorizedPersonId);
            if (authorizedPerson == null)
                return null;
            var returnAuthorizedPerson = mapper.Map<AuthorizedPerson>(authorizedPerson);
            
            returnAuthorizedPerson.buyers = context.BuyerAuthorizedPeople.Where(e => e.authorizedPersonId == authorizedPerson.authorizedPersonId).ToList();
            return returnAuthorizedPerson;
        }

        public List<AuthorizedPerson> GetAuthorizedPersons()
        {
            var authorizedPeople = this.context.AuthorizedPeople.ToList();
            if (authorizedPeople == null || authorizedPeople.Count == 0)
                return null;
            List<AuthorizedPerson> returnList = mapper.Map<List<AuthorizedPerson>>(authorizedPeople);
            foreach (var el in returnList)
            {
                el.buyers = context.BuyerAuthorizedPeople.Where(e => e.authorizedPersonId == el.authorizedPersonId).ToList();
            }
            return returnList;
        }

        
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateAuthorizedPerson(AuthorizedPersonUpdate authorizedPerson)
        {
            var authorizedPersonToUpdate = context.AuthorizedPeople.FirstOrDefault(e => e.authorizedPersonId == authorizedPerson.authorizedPersonId);
            var buyers = context.BuyerAuthorizedPeople.Where(e => e.authorizedPersonId == authorizedPerson.authorizedPersonId).ToList();

            context.Remove(buyers);

            foreach(var el in authorizedPerson.buyerIds)
            {
                var temp = new BuyerAuthorizedPersonConnection();
                temp.buyerId = el;
                temp.authorizedPersonId = authorizedPerson.authorizedPersonId;
                context.Add(temp);
            }

            var newValues = mapper.Map<AuthorizedPersonWithoutLists>(authorizedPerson);
            mapper.Map(newValues, authorizedPersonToUpdate);
        }

        public void DeleteAuthorizedPerson(Guid authorizedPersonId)
        {
            var authorizedPersonToDelete = context.AuthorizedPeople.FirstOrDefault(e => e.authorizedPersonId == authorizedPersonId);
            var listOfBuyers = this.context.BuyerAuthorizedPeople.Where(e => e.authorizedPersonId == authorizedPersonId).ToList();

            context.RemoveRange(listOfBuyers);
            context.Remove(authorizedPersonToDelete);
        }
    }
}
