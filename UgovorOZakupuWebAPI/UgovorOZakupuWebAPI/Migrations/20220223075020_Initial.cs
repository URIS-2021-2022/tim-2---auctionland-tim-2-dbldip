using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UgovorOZakupuWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractedPublicBiddings",
                columns: table => new
                {
                    ContractedPublicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractedPublicBiddings", x => x.ContractedPublicBiddingId);
                });

            migrationBuilder.CreateTable(
                name: "ContractParties",
                columns: table => new
                {
                    ContractPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractParties", x => x.ContractPartyId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAuthors",
                columns: table => new
                {
                    DocumentAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgencyInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAuthors", x => x.DocumentAuthorId);
                });

            migrationBuilder.CreateTable(
                name: "GuaranteeTypes",
                columns: table => new
                {
                    GuaranteeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuaranteeTypes", x => x.GuaranteeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentAdoptionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentAuthors_DocumentAuthorId",
                        column: x => x.DocumentAuthorId,
                        principalTable: "DocumentAuthors",
                        principalColumn: "DocumentAuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaseAgreements",
                columns: table => new
                {
                    LeaseAgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LandReturnDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfSigning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfSigning = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ContractedPublicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContractPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GuaranteeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DecisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseAgreements", x => x.LeaseAgreementId);
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_ContractedPublicBiddings_ContractedPublicBiddingId",
                        column: x => x.ContractedPublicBiddingId,
                        principalTable: "ContractedPublicBiddings",
                        principalColumn: "ContractedPublicBiddingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_ContractParties_ContractPartyId",
                        column: x => x.ContractPartyId,
                        principalTable: "ContractParties",
                        principalColumn: "ContractPartyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_Documents_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaseAgreements_GuaranteeTypes_GuaranteeTypeId",
                        column: x => x.GuaranteeTypeId,
                        principalTable: "GuaranteeTypes",
                        principalColumn: "GuaranteeTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaturityDeadlines",
                columns: table => new
                {
                    MaturityDeadlineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaseAgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deadline = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaturityDeadlines", x => x.MaturityDeadlineId);
                    table.ForeignKey(
                        name: "FK_MaturityDeadlines_LeaseAgreements_LeaseAgreementId",
                        column: x => x.LeaseAgreementId,
                        principalTable: "LeaseAgreements",
                        principalColumn: "LeaseAgreementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContractParties",
                column: "ContractPartyId",
                value: new Guid("2426e609-5dd9-4817-8d32-d63a032402ac"));

            migrationBuilder.InsertData(
                table: "ContractedPublicBiddings",
                columns: new[] { "ContractedPublicBiddingId", "AdditionalInfo" },
                values: new object[] { new Guid("55ee6acb-39fd-4464-a5f6-29f9767b82b5"), "Nema dodatnih informacija." });

            migrationBuilder.InsertData(
                table: "DocumentAuthors",
                columns: new[] { "DocumentAuthorId", "AgencyInfo" },
                values: new object[] { new Guid("554c65b1-56af-4050-b232-c20d7197bb78"), "Agencija za zavod 021" });

            migrationBuilder.InsertData(
                table: "GuaranteeTypes",
                columns: new[] { "GuaranteeTypeId", "Type" },
                values: new object[,]
                {
                    { new Guid("a0999e21-b0e4-4c41-909c-b3cc1a4520a7"), "Jemstvo" },
                    { new Guid("0c779a8e-6509-4814-b1db-350a3335dd01"), "Bankarska Garancija" },
                    { new Guid("fec2697e-8ddd-4dca-9efc-d5214e5b988e"), "Garancija nekretninom" },
                    { new Guid("677c878c-ffdb-4188-aba6-0bd45b6a680e"), "Žirantska" },
                    { new Guid("d751aa4b-936c-4b23-bdbe-be6081235133"), "Uplata gotovinom" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "DocumentId", "Date", "DocumentAdoptionDate", "DocumentAuthorId", "FileNumber", "Template" },
                values: new object[] { new Guid("68ee654e-31f4-40ca-be06-aa95b7356712"), null, null, new Guid("554c65b1-56af-4050-b232-c20d7197bb78"), "File001", "template2" });

            migrationBuilder.InsertData(
                table: "LeaseAgreements",
                columns: new[] { "LeaseAgreementId", "ContractPartyId", "ContractedPublicBiddingId", "DateOfSigning", "DecisionId", "GuaranteeTypeId", "LandReturnDeadline", "PlaceOfSigning", "RecordDate", "SerialNumber" },
                values: new object[] { new Guid("5a10ccf3-d021-49a9-9844-244c3ac30ebe"), new Guid("2426e609-5dd9-4817-8d32-d63a032402ac"), new Guid("55ee6acb-39fd-4464-a5f6-29f9767b82b5"), null, new Guid("68ee654e-31f4-40ca-be06-aa95b7356712"), new Guid("d751aa4b-936c-4b23-bdbe-be6081235133"), null, "Novi Sad", null, "012392" });

            migrationBuilder.InsertData(
                table: "MaturityDeadlines",
                columns: new[] { "MaturityDeadlineId", "Deadline", "LeaseAgreementId" },
                values: new object[] { new Guid("f209322d-66e9-46f3-8f34-65d816d4de5a"), 2, new Guid("5a10ccf3-d021-49a9-9844-244c3ac30ebe") });

            migrationBuilder.InsertData(
                table: "MaturityDeadlines",
                columns: new[] { "MaturityDeadlineId", "Deadline", "LeaseAgreementId" },
                values: new object[] { new Guid("4546fd1d-aebf-4423-9d11-0a5908ce1aa8"), 1, new Guid("5a10ccf3-d021-49a9-9844-244c3ac30ebe") });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentAuthorId",
                table: "Documents",
                column: "DocumentAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_ContractedPublicBiddingId",
                table: "LeaseAgreements",
                column: "ContractedPublicBiddingId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_ContractPartyId",
                table: "LeaseAgreements",
                column: "ContractPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_DecisionId",
                table: "LeaseAgreements",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreements_GuaranteeTypeId",
                table: "LeaseAgreements",
                column: "GuaranteeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaturityDeadlines_LeaseAgreementId",
                table: "MaturityDeadlines",
                column: "LeaseAgreementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaturityDeadlines");

            migrationBuilder.DropTable(
                name: "LeaseAgreements");

            migrationBuilder.DropTable(
                name: "ContractedPublicBiddings");

            migrationBuilder.DropTable(
                name: "ContractParties");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "GuaranteeTypes");

            migrationBuilder.DropTable(
                name: "DocumentAuthors");
        }
    }
}
