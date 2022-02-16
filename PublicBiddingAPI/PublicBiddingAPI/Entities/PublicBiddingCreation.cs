using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    public class PublicBiddingCreation
    {
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public List<Guid> plotIds { get; set; }
        public double startingPricePerHectare { get; set; }
        public bool excepted { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        public Guid bestBidderId { get; set; }
        public Guid cadastralMunicipalityId { get; set; }
        public double leasePeriod { get; set; }
        public List<Guid> appliedBuyersId { get; set; }
        public List<Guid> biddersId { get; set; }
        public int numbOfParticipants { get; set; }
        public double deposit { get; set; }
        public int round { get; set; }
    }
}
