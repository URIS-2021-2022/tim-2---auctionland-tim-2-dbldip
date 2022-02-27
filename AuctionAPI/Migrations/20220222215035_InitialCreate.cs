using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionPublicBidding",
                columns: table => new
                {
                    auctionPublicBiddingConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionPublicBidding", x => x.auctionPublicBiddingConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    auctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    auctionNumber = table.Column<int>(type: "int", nullable: false),
                    auctionYear = table.Column<int>(type: "int", nullable: false),
                    biddingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    limit = table.Column<int>(type: "int", nullable: false),
                    priceStep = table.Column<int>(type: "int", nullable: false),
                    registryClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.auctionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionPublicBidding");

            migrationBuilder.DropTable(
                name: "Auctions");
        }
    }
}
