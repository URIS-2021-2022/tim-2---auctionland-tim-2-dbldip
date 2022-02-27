using System;
using System.ComponentModel.DataAnnotations;

namespace PublicBiddingAPI.Entities
{
    /// <summary>
    /// Entity that serves as template for root table 
    /// </summary>
    public class PublicBiddingWithoutLists
    {
        [Key]
        public Guid publicBiddingId { get; set; }
        public DateTime date { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        public double startingPricePerHectare { get; set; }
        public bool excepted { get; set; }
        public TypeOfPublicBidding typeOfPublicBidding { get; set; }
        public double bestBid { get; set; }
        public CadastralMunicipality cadastralMunicipality { get; set; }
        public double leasePeriod { get; set; }
        public int numbOfParticipants { get; set; }
        public double deposit { get; set; }
        public int round { get; set; }
        public bool isDelete { get; set; }
    }
}
