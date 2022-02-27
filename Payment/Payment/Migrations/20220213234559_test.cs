using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    exchangeRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    currencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.exchangeRateId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentServices",
                columns: table => new
                {
                    PaymentServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    referenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: false),
                    payerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    payerIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payerAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentServicePurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    publicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    publicBiddingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    startingPricePerHectare = table.Column<int>(type: "int", nullable: false),
                    exception = table.Column<bool>(type: "bit", nullable: false),
                    licitatedPrice = table.Column<int>(type: "int", nullable: false),
                    exchangeRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    currencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentServices", x => x.PaymentServiceId);
                });

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "exchangeRateId", "currencyCode", "currencyName", "currencyPrice" },
                values: new object[,]
                {
                    { new Guid("0bc832c3-5e95-49fc-a8d4-fb7780615efd"), "EUR", "EURO", 117.584 },
                    { new Guid("25c03215-b093-43cb-ba76-30d1d51fd7c6"), "USD", "US Dollar", 103.298 },
                    { new Guid("d2391865-62a4-4172-b485-23930645055a"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("3ac939a6-cf23-472e-b829-ebd8c9c8f890"), "GBP", "Pound sterling", 139.73099999999999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "PaymentServices");
        }
    }
}
