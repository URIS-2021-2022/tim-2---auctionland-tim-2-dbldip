using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    completeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    townInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addressId);
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
                name: "Country",
                columns: table => new
                {
                    countryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    personId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.personId);
                    table.ForeignKey(
                        name: "FK_Person_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "addressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizedPeople",
                columns: table => new
                {
                    authorizedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jmbg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    countryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedPeople", x => x.authorizedPersonId);
                    table.ForeignKey(
                        name: "FK_AuthorizedPeople_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "addressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorizedPeople_Country_countryId",
                        column: x => x.countryId,
                        principalTable: "Country",
                        principalColumn: "countryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    personId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    realizedArea = table.Column<int>(type: "int", nullable: false),
                    hasBan = table.Column<bool>(type: "bit", nullable: false),
                    dateOfBanStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateOfBanEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    banDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.buyerId);
                    table.ForeignKey(
                        name: "FK_Buyers_Person_personId",
                        column: x => x.personId,
                        principalTable: "Person",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizedPeople_addressId",
                table: "AuthorizedPeople",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizedPeople_countryId",
                table: "AuthorizedPeople",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_personId",
                table: "Buyers",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_addressId",
                table: "Person",
                column: "addressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizedPeople");

            migrationBuilder.DropTable(
                name: "BuyerPayments");

            migrationBuilder.DropTable(
                name: "BuyerPeople");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
