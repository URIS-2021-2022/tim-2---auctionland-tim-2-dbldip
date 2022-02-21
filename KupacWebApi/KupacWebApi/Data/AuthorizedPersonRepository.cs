using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Entities.ConnectionClasses;
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
                var temp = new AuthorizedPersonBuyerConnection();
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
            returnAuthorizedPerson.buyers = context.AuthorizedPeopleBuyers.Where(e => e.authorizedPersonId == authorizedPerson.authorizedPersonId).ToList();
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
                el.buyers = context.AuthorizedPeopleBuyers.Where(e => e.authorizedPersonId == el.authorizedPersonId).ToList();
            }
            return returnList;
        }

        public void DeleteAuthorizedPerson(Guid authorizedPersonId)
        {
            var authorizedPersonToDelete = GetAuthorizedPerson(authorizedPersonId);
            authorizedPersonToDelete.isDelete = true;
            UpdateAuthorizedPerson(authorizedPersonToDelete);
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateAuthorizedPerson(AuthorizedPerson authorizedPerson)
        {
            
        }
    }
}
