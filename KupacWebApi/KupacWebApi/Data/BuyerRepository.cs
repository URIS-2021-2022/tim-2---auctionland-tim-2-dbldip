using KupacWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Data
{
    public class BuyerRepository : IBuyerRepository
    {
        public BuyerConfirmation createBuyer(BuyerCreation buyer)
        {
            
        }

        public void DeleteBuyer(Guid buyerId)
        {
            throw new NotImplementedException();
        }

        public List<Buyer> getAllBuyers()
        {
            throw new NotImplementedException();
        }

        public Buyer getBuyer(Guid buyerId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateBuyer(Buyer buyer)
        {
            throw new NotImplementedException();
        }
    }
}
