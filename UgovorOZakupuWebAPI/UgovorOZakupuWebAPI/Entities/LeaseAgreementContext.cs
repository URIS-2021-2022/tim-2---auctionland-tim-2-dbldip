using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class LeaseAgreementContext : DbContext
    {
        private readonly IConfiguration configuration;

        public List<Document> Documents = new List<Document>();
        public List<GuaranteeType> GuaranteeTypes = new List<GuaranteeType>();
        public List<ContractParty> ContractParties = new List<ContractParty>();
        public List<DocumentAuthor> DocumentAuthors = new List<DocumentAuthor>();
        public List<ContractedPublicBidding> ContractedPublicBiddings = new List<ContractedPublicBidding>();
    }
}
