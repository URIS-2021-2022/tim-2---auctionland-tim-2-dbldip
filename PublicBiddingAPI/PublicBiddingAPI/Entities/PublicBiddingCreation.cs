using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Creation Entity of Public Bidding
    /// </summary>
    public class PublicBiddingCreation
    {
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        /// <summary>
        /// List of plot ids
        /// </summary>
        public List<Guid> plotIds { get; set; }
        public double startingPricePerHectare { get; set; }
        public bool excepted { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        /// <summary>
        /// Winning buyer id
        /// </summary>
        public Guid bestBidderId { get; set; }
        /// <summary>
        /// Cadastral municipality id
        /// </summary>
        public Guid cadastralMunicipalityId { get; set; }
        public double leasePeriod { get; set; }
        /// <summary>
        /// List of applied buyers ids
        /// </summary>
        public List<Guid> appliedBuyersId { get; set; }
        /// <summary>
        /// List of competing bidder ids
        /// </summary>
        public List<Guid> biddersId { get; set; }
        public int numbOfParticipants { get; set; }
        public double deposit { get; set; }
        public int round { get; set; }
    }
}
