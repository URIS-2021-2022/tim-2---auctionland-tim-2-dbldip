using AuctionAPI.Entities;
using AuctionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Data
{

    public class AuctionCreationRepository : IAuctionCreationRepository
    {
        public static List<AuctionCreationDto> AuctionCreations { get; set; } = new List<AuctionCreationDto>();

        public AuctionCreation CreateAuctionCreation(CreationDto auctionCreation)
        {
            throw new NotImplementedException();
        }

        //Delete auctionCreation
        public void DeleteAuctionCreation(Guid auctionId)
        {
            throw new NotImplementedException();
        }

        //Get by bidding date
        public AuctionCreationDto GetAuctionCreationByBiddingDate(DateTime biddingDate)
        {
            throw new NotImplementedException();
        }

        //Get auction creation by id
        public AuctionCreationDto GetAuctionCreationById(Guid auctionId)
        {
            throw new NotImplementedException();
        }

        //Get auction creation by number
        public AuctionCreationDto GetAuctionCreationByNumber(int auctionNumber)
        {
            throw new NotImplementedException();
        }

        //Get all auction creations
        public List<AuctionCreationDto> GetAuctionCreations()
        {
            throw new NotImplementedException();
        }

        //Update auction creation
        public AuctionCreationDto UpdateAuctionCreation(AuctionCreationDto auctionCreation)
        {
            throw new NotImplementedException();
        }

        public AuctionCreation UpdateAuctionCreation(CreationDto auctionCreation)
        {
            throw new NotImplementedException();
        }

        AuctionCreation IAuctionCreationRepository.GetAuctionCreationByBiddingDate(DateTime biddingDate)
        {
            throw new NotImplementedException();
        }

        AuctionCreation IAuctionCreationRepository.GetAuctionCreationById(Guid auctionId)
        {
            throw new NotImplementedException();
        }

        AuctionCreation IAuctionCreationRepository.GetAuctionCreationByNumber(int auctionNumber)
        {
            throw new NotImplementedException();
        }

        List<AuctionCreation> IAuctionCreationRepository.GetAuctionCreations()
        {
            throw new NotImplementedException();
        }
    }
}
