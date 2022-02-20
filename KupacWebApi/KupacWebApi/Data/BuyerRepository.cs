using AutoMapper;
using KupacWebApi.Entities;
using KupacWebApi.Entities.ConnectionClasses;
using KupacWebApi.Entities.OtherAgregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Data
{
    public class BuyerRepository : IBuyerRepository
    {

        private readonly BuyerContext context;
        private readonly IMapper mapper;

        public BuyerRepository (BuyerContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public BuyerConfirmation CreateBuyer(BuyerCreation buyer)
        {
            var mappedEntity = mapper.Map<BuyerWithoutLists>(buyer);
            var createdEntity = context.Add(mappedEntity);

            foreach (var el in buyer.publicBiddingIds)
            {
                var temp = new BuyerPublicBiddingConnection();
                temp.publicBiddingId = el;
                temp.buyerId = createdEntity.Entity.buyerId;
                context.Add(temp);
            }

            foreach (var el in buyer.paymentIds)
            {
                var temp = new BuyerPaymentConnection();
                temp.payerId = el;
                temp.buyerId = createdEntity.Entity.buyerId;
                context.Add(temp);
            }

            foreach (var el in buyer.paymentIds)
            {
                var temp = new BuyerAuthorizedPersonConnection();
                temp.authorizedPersonId = el;
                temp.buyerId = createdEntity.Entity.buyerId;
                context.Add(temp);
            }

            var person = new BuyerPersonConnection();
            person.personId = buyer.personId;
            person.buyerId = createdEntity.Entity.buyerId;
            context.Add(person);

            return mapper.Map<BuyerConfirmation>(createdEntity.Entity);
        }
        
        public Buyer GetBuyer(Guid buyerId)
        {
            throw new NotImplementedException();
        }

        public List<Buyer> GetBuyers()
        {
            throw new NotImplementedException();
        }

       
        public void UpdateBuyer(Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public void DeleteBuyer(Guid buyerId)
        {
            throw new NotImplementedException();
        }


        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

    }
}
