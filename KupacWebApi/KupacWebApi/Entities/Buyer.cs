using KupacWebApi.Entities.ConnectionClasses;
using KupacWebApi.Entities.OtherAgregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KupacWebApi.Entities
{
    public class Buyer
    {
        public Guid buyerId { get; set; }
        public BuyerPersonConnection person { get; set; }
        public int realizedArea { get; set; }
        public bool hasBan { get; set; }
        public DateTime dateOfBanStart { get; set; }
        public DateTime dateOfBanEnd { get; set; }
        public int banDuration { get; set; }
        public List <BuyerPublicBiddingConnection> publicBiddings { get; set; }
        public List<BuyerPaymentConnection> payments { get; set; }
        public List<BuyerAuthorizedPersonConnection> authorizedPeople { get; set; }
        public bool isDelete { get; set; }

    }
}
