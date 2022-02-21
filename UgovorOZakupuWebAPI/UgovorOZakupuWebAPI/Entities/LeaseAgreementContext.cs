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
        public LeaseAgreementContext(DbContextOptions options) : base(options)
        {
        }

        public List<Document> Documents = new List<Document>();
        public List<GuaranteeType> GuaranteeTypes = new List<GuaranteeType>();
        public List<ContractParty> ContractParties = new List<ContractParty>();
        public List<DocumentAuthor> DocumentAuthors = new List<DocumentAuthor>();
        public List<ContractedPublicBidding> ContractedPublicBiddings = new List<ContractedPublicBidding>();
        public List<LeaseAgreement> LeaseAgreements = new List<LeaseAgreement>();
        public List<MaturityDeadline> MaturityDeadlines = new List<MaturityDeadline>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DocumentAuthor>()
                .HasData(new
                {
                    DocumentAuthorId = Guid.Parse("554c65b1-56af-4050-b232-c20d7197bb78"),
                    AgencyInfo = "Agencija za zavod 021"
                });
            builder.Entity<ContractedPublicBidding>()
                .HasData(new
                {
                    ContractedPublicBiddingId = Guid.Parse("55ee6acb-39fd-4464-a5f6-29f9767b82b5"),
                    AdditionalInfo = "Nema dodatnih informacija."
                });
            builder.Entity<GuaranteeType>()
                .HasData(new
                {
                    GuaranteeTypeId = Guid.Parse("d751aa4b-936c-4b23-bdbe-be6081235133"),
                    Type = "Jemstvo"
                });
            builder.Entity<ContractParty>()
                .HasData(new
                {
                    ContractPartyId = Guid.Parse("2426e609-5dd9-4817-8d32-d63a032402ac")
                });
            builder.Entity<Document>()
                .HasData(new
                {
                    DocumentId = Guid.Parse("68ee654e-31f4-40ca-be06-aa95b7356712"),
                    FileNumber = "File001",
                    Template = "template2",
                    DocumentAuthorId = Guid.Parse("554c65b1-56af-4050-b232-c20d7197bb78")
                });
            builder.Entity<LeaseAgreement>()
                .Property("IsDelete")
                .HasDefaultValue(false);
            builder.Entity<LeaseAgreement>()
                .HasData(new
                {
                    LeaseAgreementId = Guid.Parse("5a10ccf3-d021-49a9-9844-244c3ac30ebe"),
                    SerialNumber = "012392",
                    PlaceOfSigning = "Novi Sad",
                    ContractedPublicBiddingId = Guid.Parse("55ee6acb-39fd-4464-a5f6-29f9767b82b5"),
                    ContractPartyId = Guid.Parse("2426e609-5dd9-4817-8d32-d63a032402ac"),
                    GuaranteeTypeId = Guid.Parse("d751aa4b-936c-4b23-bdbe-be6081235133"),
                    DecisionId = Guid.Parse("68ee654e-31f4-40ca-be06-aa95b7356712")
                });
            builder.Entity<MaturityDeadline>()
                .HasData(new
                {
                    MaturityDeadlineId = Guid.Parse("f209322d-66e9-46f3-8f34-65d816d4de5a"),
                    LeaseAgreementId = Guid.Parse("5a10ccf3-d021-49a9-9844-244c3ac30ebe"),
                    Deadline = 2
                });
            builder.Entity<MaturityDeadline>()
               .HasData(new
               {
                   MaturityDeadlineId = Guid.Parse("4546fd1d-aebf-4423-9d11-0a5908ce1aa8"),
                   LeaseAgreementId = Guid.Parse("5a10ccf3-d021-49a9-9844-244c3ac30ebe"),
                   Deadline = 1
               });
        }
    }
}
