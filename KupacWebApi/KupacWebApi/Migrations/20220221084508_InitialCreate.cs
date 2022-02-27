using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizedPeople",
                columns: table => new
                {
                    authorizedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jmbg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedPeople", x => x.authorizedPersonId);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizedPeopleBuyers",
                columns: table => new
                {
                    authorizedPersonBuyerConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    authorizedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedPeopleBuyers", x => x.authorizedPersonBuyerConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "BuyerAuthorizedPeople",
                columns: table => new
                {
                    buyerAuthorizedPersonConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    authorizedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerAuthorizedPeople", x => x.buyerAuthorizedPersonConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "BuyerPayments",
                columns: table => new
                {
                    buyerPaymentConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    payerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerPayments", x => x.buyerPaymentConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "BuyerPeople",
                columns: table => new
                {
                    buyerPersonConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    personId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerPeople", x => x.buyerPersonConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "BuyerPublicBiddings",
                columns: table => new
                {
                    buyerPublicBiddingConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerPublicBiddings", x => x.buyerPublicBiddingConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    realizedArea = table.Column<int>(type: "int", nullable: false),
                    hasBan = table.Column<bool>(type: "bit", nullable: false),
                    dateOfBanStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateOfBanEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    banDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.buyerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizedPeople");

            migrationBuilder.DropTable(
                name: "AuthorizedPeopleBuyers");

            migrationBuilder.DropTable(
                name: "BuyerAuthorizedPeople");

            migrationBuilder.DropTable(
                name: "BuyerPayments");

            migrationBuilder.DropTable(
                name: "BuyerPeople");

            migrationBuilder.DropTable(
                name: "BuyerPublicBiddings");

            migrationBuilder.DropTable(
                name: "Buyers");
        }
    }
}
