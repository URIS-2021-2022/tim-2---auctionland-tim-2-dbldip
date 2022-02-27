using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Data
{
    public class TypeOfPublicBiddingRepository : ITypeOfPublicBiddingRepository
    {
        private readonly PublicBiddingContext context;

        public TypeOfPublicBiddingRepository(PublicBiddingContext context)
        {
            this.context = context;
        }

        public List<TypeOfPublicBidding> getAllTypesOfPublicBidding()
        {
            return context.TypesOfPublicBidding.ToList();
        }

        public TypeOfPublicBidding getTypeOfPublicBiddingById(Guid typeId)
        {
            return context.TypesOfPublicBidding.FirstOrDefault(e => e.typeOfPublicBiddingId == typeId);
        }

        public TypeOfPublicBidding GetTypeOfPublicBiddingByName(string typeName)
        {
            return context.TypesOfPublicBidding.FirstOrDefault(e => e.typeOfPublicBiddingName == typeName);
        }
    }
}
