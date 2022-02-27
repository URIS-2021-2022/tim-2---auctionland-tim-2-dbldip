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

        public DbSet<Document> Documents { get; set; }
        public DbSet<GuaranteeType> GuaranteeTypes { get; set; }
        public DbSet<ContractParty> ContractParties { get; set; }
        public DbSet<DocumentAuthor> DocumentAuthors { get; set; }
        public DbSet<ContractedPublicBidding> ContractedPublicBiddings { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
        public DbSet<MaturityDeadline> MaturityDeadlines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentAuthor>()
                .HasData(new
                {
                    DocumentAuthorId = Guid.Parse("554c65b1-56af-4050-b232-c20d7197bb78"),
                    AgencyInfo = "Agencija za zavod 021"
                });
            modelBuilder.Entity<ContractedPublicBidding>()
                .HasData(new
                {
                    ContractedPublicBiddingId = Guid.Parse("55ee6acb-39fd-4464-a5f6-29f9767b82b5"),
                    AdditionalInfo = "Nema dodatnih informacija."
                });
            modelBuilder.Entity<GuaranteeType>()
                .HasData(new
                {
                    GuaranteeTypeId = Guid.Parse("a0999e21-b0e4-4c41-909c-b3cc1a4520a7"),
                    Type = "Jemstvo"
                });
            modelBuilder.Entity<GuaranteeType>()
                .HasData(new
                {
                    GuaranteeTypeId = Guid.Parse("0c779a8e-6509-4814-b1db-350a3335dd01"),
                    Type = "Bankarska Garancija"
                });
            modelBuilder.Entity<GuaranteeType>()
                .HasData(new
                {
                    GuaranteeTypeId = Guid.Parse("fec2697e-8ddd-4dca-9efc-d5214e5b988e"),
                    Type = "Garancija nekretninom"
                });
            modelBuilder.Entity<GuaranteeType>()
                .HasData(new
                {
                    GuaranteeTypeId = Guid.Parse("677c878c-ffdb-4188-aba6-0bd45b6a680e"),
                    Type = "Žirantska"
                });
            modelBuilder.Entity<GuaranteeType>()
                .HasData(new
                {
                    GuaranteeTypeId = Guid.Parse("d751aa4b-936c-4b23-bdbe-be6081235133"),
                    Type = "Uplata gotovinom"
                });
            modelBuilder.Entity<ContractParty>()
                .HasData(new
                {
                    ContractPartyId = Guid.Parse("2426e609-5dd9-4817-8d32-d63a032402ac")
                });
            modelBuilder.Entity<Document>()
                .HasData(new
                {
                    DocumentId = Guid.Parse("68ee654e-31f4-40ca-be06-aa95b7356712"),
                    FileNumber = "File001",
                    Template = "template2",
                    DocumentAuthorId = Guid.Parse("554c65b1-56af-4050-b232-c20d7197bb78")
                });
            modelBuilder.Entity<LeaseAgreement>()
                .Property("IsDelete")
                .HasDefaultValue(false);
            modelBuilder.Entity<LeaseAgreement>()
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
            modelBuilder.Entity<MaturityDeadline>()
                .HasData(new
                {
                    MaturityDeadlineId = Guid.Parse("f209322d-66e9-46f3-8f34-65d816d4de5a"),
                    LeaseAgreementId = Guid.Parse("5a10ccf3-d021-49a9-9844-244c3ac30ebe"),
                    Deadline = 2
                });
            modelBuilder.Entity<MaturityDeadline>()
               .HasData(new
               {
                   MaturityDeadlineId = Guid.Parse("4546fd1d-aebf-4423-9d11-0a5908ce1aa8"),
                   LeaseAgreementId = Guid.Parse("5a10ccf3-d021-49a9-9844-244c3ac30ebe"),
                   Deadline = 1
               });
        }
    }
}
