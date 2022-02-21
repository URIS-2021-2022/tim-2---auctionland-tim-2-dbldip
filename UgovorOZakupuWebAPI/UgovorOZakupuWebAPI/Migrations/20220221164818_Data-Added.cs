using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UgovorOZakupuWebAPI.Migrations
{
    public partial class DataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractedPublicBidding",
                columns: table => new
                {
                    ContractedPublicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractedPublicBidding", x => x.ContractedPublicBiddingId);
                });

            migrationBuilder.CreateTable(
                name: "ContractParty",
                columns: table => new
                {
                    ContractPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractParty", x => x.ContractPartyId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentAuthor",
                columns: table => new
                {
                    DocumentAuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgencyInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentAuthor", x => x.DocumentAuthorId);
                });

            migrationBuilder.CreateTable(
                name: "GuaranteeType",
                columns: table => new
                {
                    GuaranteeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuaranteeType", x => x.GuaranteeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MaturityDeadline",
                columns: table => new
                {
                    MaturityDeadlineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaseAgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deadline = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaturityDeadline", x => x.MaturityDeadlineId);
                });

            migrationBuilder.CreateTable(
                name: "Document",
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
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Document_DocumentAuthor_DocumentAuthorId",
                        column: x => x.DocumentAuthorId,
                        principalTable: "DocumentAuthor",
                        principalColumn: "DocumentAuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaseAgreement",
                columns: table => new
                {
                    LeaseAgreementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LandReturnDeadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceOfSigning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfSigning = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ContractedPublicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuaranteeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DecisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaseAgreement", x => x.LeaseAgreementId);
                    table.ForeignKey(
                        name: "FK_LeaseAgreement_ContractedPublicBidding_ContractedPublicBiddingId",
                        column: x => x.ContractedPublicBiddingId,
                        principalTable: "ContractedPublicBidding",
                        principalColumn: "ContractedPublicBiddingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaseAgreement_ContractParty_ContractPartyId",
                        column: x => x.ContractPartyId,
                        principalTable: "ContractParty",
                        principalColumn: "ContractPartyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaseAgreement_Document_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Document",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaseAgreement_GuaranteeType_GuaranteeTypeId",
                        column: x => x.GuaranteeTypeId,
                        principalTable: "GuaranteeType",
                        principalColumn: "GuaranteeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContractParty",
                column: "ContractPartyId",
                value: new Guid("2426e609-5dd9-4817-8d32-d63a032402ac"));

            migrationBuilder.InsertData(
                table: "ContractedPublicBidding",
                columns: new[] { "ContractedPublicBiddingId", "AdditionalInfo" },
                values: new object[] { new Guid("55ee6acb-39fd-4464-a5f6-29f9767b82b5"), "Nema dodatnih informacija." });

            migrationBuilder.InsertData(
                table: "DocumentAuthor",
                columns: new[] { "DocumentAuthorId", "AgencyInfo" },
                values: new object[] { new Guid("554c65b1-56af-4050-b232-c20d7197bb78"), "Agencija za zavod 021" });

            migrationBuilder.InsertData(
                table: "GuaranteeType",
                columns: new[] { "GuaranteeTypeId", "Type" },
                values: new object[] { new Guid("d751aa4b-936c-4b23-bdbe-be6081235133"), "Jemstvo" });

            migrationBuilder.InsertData(
                table: "MaturityDeadline",
                columns: new[] { "MaturityDeadlineId", "Deadline", "LeaseAgreementId" },
                values: new object[,]
                {
                    { new Guid("f209322d-66e9-46f3-8f34-65d816d4de5a"), 2, new Guid("5a10ccf3-d021-49a9-9844-244c3ac30ebe") },
                    { new Guid("4546fd1d-aebf-4423-9d11-0a5908ce1aa8"), 1, new Guid("5a10ccf3-d021-49a9-9844-244c3ac30ebe") }
                });

            migrationBuilder.InsertData(
                table: "Document",
                columns: new[] { "DocumentId", "Date", "DocumentAdoptionDate", "DocumentAuthorId", "FileNumber", "Template" },
                values: new object[] { new Guid("68ee654e-31f4-40ca-be06-aa95b7356712"), null, null, new Guid("554c65b1-56af-4050-b232-c20d7197bb78"), "File001", "template2" });

            migrationBuilder.InsertData(
                table: "LeaseAgreement",
                columns: new[] { "LeaseAgreementId", "ContractPartyId", "ContractedPublicBiddingId", "DateOfSigning", "DecisionId", "GuaranteeTypeId", "LandReturnDeadline", "PlaceOfSigning", "RecordDate", "SerialNumber" },
                values: new object[] { new Guid("5a10ccf3-d021-49a9-9844-244c3ac30ebe"), new Guid("2426e609-5dd9-4817-8d32-d63a032402ac"), new Guid("55ee6acb-39fd-4464-a5f6-29f9767b82b5"), null, new Guid("68ee654e-31f4-40ca-be06-aa95b7356712"), new Guid("d751aa4b-936c-4b23-bdbe-be6081235133"), null, "Novi Sad", null, "012392" });

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentAuthorId",
                table: "Document",
                column: "DocumentAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreement_ContractedPublicBiddingId",
                table: "LeaseAgreement",
                column: "ContractedPublicBiddingId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreement_ContractPartyId",
                table: "LeaseAgreement",
                column: "ContractPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreement_DecisionId",
                table: "LeaseAgreement",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaseAgreement_GuaranteeTypeId",
                table: "LeaseAgreement",
                column: "GuaranteeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaseAgreement");

            migrationBuilder.DropTable(
                name: "MaturityDeadline");

            migrationBuilder.DropTable(
                name: "ContractedPublicBidding");

            migrationBuilder.DropTable(
                name: "ContractParty");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "GuaranteeType");

            migrationBuilder.DropTable(
                name: "DocumentAuthor");
        }
    }
}
