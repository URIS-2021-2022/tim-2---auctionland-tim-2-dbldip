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
        public List<Plot> plots { get; set; } 
        public double startingPricePerHectare { get; set; }
        public bool excepted { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        public BestBidder bestBidder { get; set; }
        public CadastralMunicipality cadastralMunicipality { get; set; } 
        public double leasePeriod { get; set; }
        public List<Buyer> appliedBuyers { get; set; }
        public List<Bidder> bidders { get; set; }
        public int numbOfParticipants { get; set; }
        public double deposit { get; set; }
        public int round { get; set; }
        public bool isDelete { get; set; }

    }
}
