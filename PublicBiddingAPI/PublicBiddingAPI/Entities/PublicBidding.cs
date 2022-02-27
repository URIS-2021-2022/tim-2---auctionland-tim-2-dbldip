using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Public Bidding Entity
    /// </summary>
    public class PublicBidding
    {
        /// <summary>
        /// Id of public bidding
        /// </summary>
        public Guid publicBiddingId { get; set; }
        /// <summary>
        /// Date of public bidding
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// Starting time of public bidding
        /// </summary>
        public DateTime startingTime { get; set; }
        /// <summary>
        /// ending time ofpublic bidding
        /// </summary>
        public DateTime endingTime { get; set; }
        /// <summary>
        /// List of plots that are auctioned
        /// </summary>
        public List<Plot> plots { get; set; }
        /// <summary>
        /// Starting price of hectare
        /// </summary>
        public double startingPricePerHectare { get; set; }

        public bool excepted { get; set; }
        /// <summary>
        /// Type of public bidding
        /// </summary>
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        /// <summary>
        /// Best bid
        /// </summary>
        public double bestBid { get; set; }
        /// <summary>
        /// Winner of bidding
        /// </summary>
        public BestBidder bestBidder { get; set; }
        /// <summary>
        /// Cadastral Municipality in which bidding is being held
        /// </summary>
        public CadastralMunicipality cadastralMunicipality { get; set; }
        /// <summary>
        /// Lease period of plots 
        /// </summary>
        public double leasePeriod { get; set; }
        /// <summary>
        /// List of applied buyers
        /// </summary>
        public List<Buyer> appliedBuyers { get; set; }
        /// <summary>
        /// List of bidders that are competing
        /// </summary>
        public List<Bidder> bidders { get; set; }
        /// <summary>
        /// Total number of participants
        /// </summary>
        public int numbOfParticipants { get; set; }
        /// <summary>
        /// Deposit
        /// </summary>
        public double deposit { get; set; }
        /// <summary>
        /// Total rounds of bidding
        /// </summary>
        public int round { get; set; }

    }
}
