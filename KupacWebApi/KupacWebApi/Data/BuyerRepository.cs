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
                return new List<Buyer>();
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

       
        public void UpdateBuyer(BuyerUpdate buyer)
        {
            var buyerToUpdate = context.Buyers.FirstOrDefault(e => e.buyerId == buyer.buyerId);

            var payments = context.BuyerPayments.Where(e => e.buyerId == buyer.buyerId).ToList();
            var person = context.BuyerPeople.FirstOrDefault(e => e.buyerId == buyer.buyerId);
            var publicBiddings = context.BuyerPublicBiddings.Where(e => e.buyerId == buyer.buyerId).ToList();
            var authorizedPeople = context.BuyerAuthorizedPeople.Where(e => e.buyerId == buyer.buyerId).ToList();

            context.RemoveRange(payments);
            context.RemoveRange(authorizedPeople);
            context.RemoveRange(publicBiddings);
            context.Remove(person);

            foreach (var el in buyer.paymentIds)
            {
                var temp = new BuyerPaymentConnection();
                temp.payerId = el;
                temp.buyerId = buyer.buyerId;
                context.Add(temp);
            }
            foreach (var el in buyer.publicBiddingIds)
            {
                var temp = new BuyerPublicBiddingConnection();
                temp.publicBiddingId = el;
                temp.buyerId = buyer.buyerId;
                context.Add(temp);
            }
            foreach (var el in buyer.authorizedPeopleIds)
            {
                var temp = new BuyerAuthorizedPersonConnection();
                temp.authorizedPersonId = el;
                temp.buyerId = buyer.buyerId;
                context.Add(temp);
            }
            var person2 = new BuyerPersonConnection();
            person2.personId = buyer.buyerId;
            person2.buyerId = buyer.buyerId;
            context.Add(person2);

            var newValues = mapper.Map<BuyerWithoutLists>(buyer);
            mapper.Map(newValues, buyerToUpdate);

        }

        public void DeleteBuyer(Guid buyerId)
        {
            var buyerToDelete = context.Buyers.FirstOrDefault(e => e.buyerId == buyerId);
            var listOfPayments = this.context.BuyerPayments.Where(e => e.buyerId == buyerId).ToList();
            var listOfPublicBiddings = this.context.BuyerPublicBiddings.Where(e => e.buyerId == buyerId).ToList();
            var listOfAuthorizedPeople = this.context.BuyerAuthorizedPeople.Where(e => e.buyerId == buyerId).ToList();
            var person = this.context.BuyerPeople.FirstOrDefault(e => e.buyerId == buyerId);

            context.RemoveRange(listOfPayments);
            context.RemoveRange(listOfPublicBiddings);
            context.RemoveRange(listOfAuthorizedPeople);
            context.Remove(person);
            context.Remove(buyerToDelete);
        }


        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
}
