using PublicBiddingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicBiddingAPI.Data
{
    public interface ITypeOfPublicBiddingRepository
    {
        List<TypeOfPublicBidding> getAllTypesOfPublicBidding();
        TypeOfPublicBidding getTypeOfPublicBiddingById(Guid typeId);
        TypeOfPublicBidding GetTypeOfPublicBiddingByName(string typeName);

    }
}
