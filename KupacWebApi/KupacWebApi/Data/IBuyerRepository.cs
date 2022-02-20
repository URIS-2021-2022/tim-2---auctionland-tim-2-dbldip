using KupacWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Data
{
    public interface IBuyerRepository
    {
        BuyerConfirmation CreateBuyer(BuyerCreation buyer);
        List<Buyer> GetBuyers();
        Buyer GetBuyer(Guid buyerId);
        void UpdateBuyer(Buyer buyer);
        void DeleteBuyer(Guid buyerId);
        bool SaveChanges();
    }
}
