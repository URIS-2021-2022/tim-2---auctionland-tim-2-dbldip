
using ComplaintAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Entities.Context
{
    /// <summary>
    /// Žalba DB Context
    /// </summary>
    public class ComplaintContext : DbContext
    {
        private readonly IConfiguration configuration;
        /// <summary>
        /// Žalba Context konstruktor
        /// </summary>
        public ComplaintContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// DbSet za status žalbe
        /// </summary>
        public DbSet<ComplaintStatus> ComplaintStatus { get; set; }
        /// <summary>
        /// DbSet za tip žalbe
        /// </summary>
        public DbSet<ComplaintType> ComplaintType { get; set; }
        /// <summary>
        /// DbSet za preuzetu radnju na osnovu žalbe 
        /// </summary>
        public DbSet<ActionTaken> ActionTaken { get; set; }
        /// <summary>
        /// DbSet za  žalbu
        /// </summary>
        public DbSet<Complaint> Complaint { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ComplaintDb"));
        }

        /// <summary>
        /// Unos podataka u bazu
        /// </summary>
        /// <param name="modelBuilder">Obezbeđuje unos podataka pri kreiranju modela</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplaintStatus>()
                .HasData(new
                {
                    complaintStatusId = Guid.Parse("6E5E8A67-006B-4AC0-89D0-9711006C0D28"),
                    complaintStatus = "Usvojena"
                },
                new
                {
                    complaintStatusId = Guid.Parse("ABDB833B-0706-4012-8689-C59BED59C6B4"),
                    complaintStatus = "Odbijena"
                },
                new
                {
                    complaintStatusId = Guid.Parse("2C1051D2-0DDF-41A9-BA08-24070A50F4B3"),
                    complaintStatus = "Otvorena"
                });

            modelBuilder.Entity<ComplaintType>()
                .HasData(new
                {
                    complaintTypeId = Guid.Parse("10EA64F1-07AB-478D-B8F3-073BCE4610F8"),
                    complaintType = "Zalba na tok javnog nadmetanja"
                },
                new
                {
                    complaintTypeId = Guid.Parse("B4947A43-42E4-4D20-A10B-169C5089AAC6"),
                    complaintType = "Zalba na Odluku o davanju u zakup"
                },
                new
                {
                    complaintTypeId = Guid.Parse("018AC715-4588-4934-BB2D-8BB2F4D1049A"),
                    complaintType = "Zalba na Odluku o davanju na koriscenje"
                });

            modelBuilder.Entity<ActionTaken>()
                .HasData(new
                {
                    actionTakenId = Guid.Parse("009AA493-7786-4AAD-9D1A-0F90D57EBBB4"),
                    actionTaken = "JN ide u drugi krug sa novim uslovima"
                },
                new
                {
                    actionTakenId = Guid.Parse("4CCB6D66-18B2-4791-8AFE-B628A4F7C0AF"),
                    actionTaken = "JN ide u drugi krug sa starim uslovima"
                },
                new
                {
                    actionTakenId = Guid.Parse("DF645DD7-3E65-41CD-A1F4-81F936A7DB49"),
                    actionTaken = "JN ne ide u drugi krug"
                });
            modelBuilder.Entity<Complaint>()
                .HasData(new
                {
                    complaintId = Guid.NewGuid(),
                    dateOfComplaint = DateTime.Now,
                    dateOfProcedure = DateTime.Now.AddDays(50),
                    complaintReason = "Nedovoljno licitanata",
                    elaboration = "Nema dovoljno licitanata da se odrzi javno nadmetanje",
                    procedureNumber = "100-NN",
                    decisionNumber = "X9NN41HH",
                    complaintStatusId = Guid.Parse("6E5E8A67-006B-4AC0-89D0-9711006C0D28"),
                    complaintTypeId = Guid.Parse("018AC715-4588-4934-BB2D-8BB2F4D1049A"),
                    actionTakenId = Guid.Parse("009AA493-7786-4AAD-9D1A-0F90D57EBBB4")
                },
                new
                {
                    complaintId = Guid.NewGuid(),
                    dateOfComplaint = DateTime.Now,
                    dateOfProcedure = DateTime.Now.AddDays(50),
                    complaintReason = "Nepotpuna dokumentacija",
                    elaboration = "Dokumentacija nije potpuna kako bi se odrzalo javno nadmetanje",
                    procedureNumber = "200-OO",
                    decisionNumber = "IIKK-55",
                    complaintStatusId = Guid.Parse("6E5E8A67-006B-4AC0-89D0-9711006C0D28"),
                    complaintTypeId = Guid.Parse("B4947A43-42E4-4D20-A10B-169C5089AAC6"),
                    actionTakenId = Guid.Parse("009AA493-7786-4AAD-9D1A-0F90D57EBBB4")
                },
                new
                {
                    complaintId = Guid.NewGuid(),
                    dateOfComplaint = DateTime.Now,
                    dateOfProcedure = DateTime.Now.AddDays(50),
                    complaintReason = "Nedovoljno uplacenih novcanih sredstava",
                    elaboration = "Nema dovoljno novcanih sredstava za javno nadmetanje",
                    procedureNumber = "999-AA",
                    decisionNumber = "QWOP44-MM",
                    complaintStatusId = Guid.Parse("2C1051D2-0DDF-41A9-BA08-24070A50F4B3"),
                    complaintTypeId = Guid.Parse("B4947A43-42E4-4D20-A10B-169C5089AAC6"),
                    actionTakenId = Guid.Parse("4CCB6D66-18B2-4791-8AFE-B628A4F7C0AF")
                });
        }

    }
}
