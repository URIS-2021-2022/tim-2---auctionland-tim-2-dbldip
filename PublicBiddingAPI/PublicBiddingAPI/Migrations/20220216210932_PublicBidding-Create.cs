using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicBiddingAPI.Migrations
{
    public partial class PublicBiddingCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppliedBuyers",
                columns: table => new
                {
                    buyerConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedBuyers", x => x.buyerConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "BestBidders",
                columns: table => new
                {
                    bestBidderConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bestBidderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestBidders", x => x.bestBidderConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "Bidders",
                columns: table => new
                {
                    bidderConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    bidderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bidders", x => x.bidderConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "CadastralMunicipality",
                columns: table => new
                {
                    cadastralMuniciplaityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cadastralMunicipalityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastralMunicipality", x => x.cadastralMuniciplaityId);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    plotConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    plotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.plotConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "PublicBiddings",
                columns: table => new
                {
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startingPricePerHectare = table.Column<double>(type: "float", nullable: false),
                    excepted = table.Column<bool>(type: "bit", nullable: false),
                    typeOfPublicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    bestBid = table.Column<double>(type: "float", nullable: false),
                    cadastralMunicipalitycadastralMuniciplaityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    leasePeriod = table.Column<double>(type: "float", nullable: false),
                    numbOfParticipants = table.Column<int>(type: "int", nullable: false),
                    deposit = table.Column<double>(type: "float", nullable: false),
                    round = table.Column<int>(type: "int", nullable: false),
                    isDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicBiddings", x => x.publicBiddingId);
                    table.ForeignKey(
                        name: "FK_PublicBiddings_CadastralMunicipality_cadastralMunicipalitycadastralMuniciplaityId",
                        column: x => x.cadastralMunicipalitycadastralMuniciplaityId,
                        principalTable: "CadastralMunicipality",
                        principalColumn: "cadastralMuniciplaityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicBiddings_TypesOfPublicBidding_typeOfPublicBiddingId",
                        column: x => x.typeOfPublicBiddingId,
                        principalTable: "TypesOfPublicBidding",
                        principalColumn: "typeOfPublicBiddingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicBiddings_cadastralMunicipalitycadastralMuniciplaityId",
                table: "PublicBiddings",
                column: "cadastralMunicipalitycadastralMuniciplaityId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicBiddings_typeOfPublicBiddingId",
                table: "PublicBiddings",
                column: "typeOfPublicBiddingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedBuyers");

            migrationBuilder.DropTable(
                name: "BestBidders");

            migrationBuilder.DropTable(
                name: "Bidders");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "PublicBiddings");

            migrationBuilder.DropTable(
                name: "CadastralMunicipality");
        }
    }
}
