using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class PublicBidding
    {
        public Guid publicBiddingId { get; set; }
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public List<Guid> plotIds { get; set; }
        //public List<Plot> plots { get; set; } //TEMPORARELY DISABLED, WILL BE ADDED WHEN PROJECTS ARE INTEGRATED
        public double startingPricePerHectare { get; set; }
        public bool excepted { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        public Guid buyerId { get; set; }
        //public Buyer bestBidder { get; set; } //TEMPORARELY DISABLED, WILL BE ADDED WHEN PROJECTS ARE INTEGRATED
        public CadastralMunicipality cadastralMunicipality { get; set; } 
        public double leasePeriod { get; set; }
        public List<Guid> appliedBuyersIds { get; set; }
        public List<Guid> biddersIds { get; set; }
        //public List<Buyer> appliedBuyers { get; set; }//TEMPORARELY DISABLED, WILL BE ADDED WHEN PROJECTS ARE INTEGRATED
        //public List<Bidder> bidders { get; set; }//TEMPORARELY DISABLED, WILL BE ADDED WHEN PROJECTS ARE INTEGRATED
        public int numbOfParticipants { get; set; }
        public double deposit { get; set; }
        public int round { get; set; }
        public bool isDeleted { get; set; }

    }
}
