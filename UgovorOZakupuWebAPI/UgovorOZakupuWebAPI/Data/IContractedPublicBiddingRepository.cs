using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public interface IContractedPublicBiddingRepository
    {
        List<ContractedPublicBidding> GetContractedPublicBiddings();
        ContractedPublicBidding GetContractedPublicBiddingById(Guid contractedPublicBiddingId);
        ContractedPublicBiddingConfirmation CreateContractedPublicBidding(ContractedPublicBidding contractedPublicBidding);
        void UpdateContractedPublicBidding(ContractedPublicBidding contractedPublicBidding);
        void DeleteContractedPublicBidding(Guid contractedPublicBiddingId);
        bool SaveChanges();
    }
}
