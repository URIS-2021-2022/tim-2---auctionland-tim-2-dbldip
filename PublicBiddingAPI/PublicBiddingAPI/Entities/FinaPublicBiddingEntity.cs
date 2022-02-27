using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class FinaPublicBiddingEntity
    {
        public Guid publicBiddingId { get; set; }
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public List<PlotEntity> plots { get; set; }
        public double startingPricePerHectare { get; set; }
        public bool excepted { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        public BestBidderEntity bestBidder { get; set; }
        public Guid cadastralMunicipality { get; set; }
        public double leasePeriod { get; set; }
        public List<BuyerEntity> appliedBuyers { get; set; }
        public List<BidderEntity> bidders { get; set; }
        public int numbOfParticipants { get; set; }
        public double deposit { get; set; }
        public int round { get; set; }
        public bool isDelete { get; set; }
    }
}
