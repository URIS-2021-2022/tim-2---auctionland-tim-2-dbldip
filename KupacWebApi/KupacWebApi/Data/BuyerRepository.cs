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
            var buyer = this.context.Buyers.FirstOrDefault(e => e.buyerId == buyerId);
            if (buyer == null)
                return null;
            var returnBuyer = mapper.Map<Buyer>(buyer);
            returnBuyer.payments = context.BuyerPayments.Where(e => e.buyerId == buyer.buyerId).ToList();
            returnBuyer.person = context.BuyerPeople.FirstOrDefault(e => e.buyerId == buyer.buyerId);
            returnBuyer.publicBiddings = context.BuyerPublicBiddings.Where(e => e.buyerId == buyer.buyerId).ToList();
            returnBuyer.authorizedPeople = context.BuyerAuthorizedPeople.Where(e => e.buyerId == buyer.buyerId).ToList();
            return returnBuyer;
        }

        public List<Buyer> GetBuyers()
        {
            var buyers = this.context.Buyers.ToList();
            if (buyers == null || buyers.Count == 0)
                return null;
            List<Buyer> returnList = mapper.Map<List<Buyer>>(buyers);
            foreach (var el in returnList)
            {
                el.payments = context.BuyerPayments.Where(e => e.buyerId == el.buyerId).ToList();
                el.person = context.BuyerPeople.FirstOrDefault(e => e.buyerId == el.buyerId);
                el.publicBiddings = context.BuyerPublicBiddings.Where(e => e.buyerId == el.buyerId).ToList();
                el.authorizedPeople = context.BuyerAuthorizedPeople.Where(e => e.buyerId == el.buyerId).ToList();
            }
            return returnList;
        }

       
        public void UpdateBuyer(Buyer buyer)
        {
            
        }

        public void DeleteBuyer(Guid buyerId)
        {
            var buyerToDelete = GetBuyer(buyerId);
            buyerToDelete.isDelete = true;
            UpdateBuyer(buyerToDelete);
        }


        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
}
