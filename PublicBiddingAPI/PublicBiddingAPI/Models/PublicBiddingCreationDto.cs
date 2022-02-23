using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Models
{
    /// <summary>
    /// Dto object sent to the server when sending POST request
    /// </summary>
    public class PublicBiddingCreationDto
    {
        /// <summary>
        /// date of public bidding
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// start time of the bidding
        /// </summary>
        public DateTime startingTime { get; set; }
        /// <summary>
        /// end time of bidding
        /// </summary>
        public DateTime endingTime { get; set; }
        /// <summary>
        /// plots that are being bid on
        /// </summary>
        public List<Guid> plotIds { get; set; }
        /// <summary>
        /// price per hectare
        /// </summary>
        public double startingPricePerHectare { get; set; }
        /// <summary>
        /// is the bidding being excepted
        /// </summary>
        public bool excepted { get; set; }
        /// <summary>
        /// Type of public bidding
        /// </summary>
        public string typeOfPublicBiddingName { get; set; }
        /// <summary>
        /// bid that won the bidding
        /// </summary>
        public double bestBid { get; set; }
        /// <summary>
        /// id of buyer that won the bidding
        /// </summary>
        public Guid bestBidderId { get; set; }
        /// <summary>
        /// Id of municipality bidding is being held in
        /// </summary>
        public Guid cadastralMunicipalityId { get; set; }
        /// <summary>
        /// lease period of plots being bid on
        /// </summary>
        public double leasePeriod { get; set; }
        /// <summary>
        /// List of ids of applied buyers
        /// </summary>
        public List<Guid> appliedBuyersId { get; set; }
        /// <summary>
        /// list of ids of bidders competing in the bidding
        /// </summary>
        public List<Guid> biddersId { get; set; }
        /// <summary>
        /// total number of participants
        /// </summary>
        public int numbOfParticipants { get; set; }
        public double deposit { get; set; }
        public int round { get; set; }

    }
}
