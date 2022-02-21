using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class testingLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("3dea0188-24be-480e-a053-5a6a4c98079c"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("50f05730-9943-40c2-8574-d3d4ab0e1f46"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("5e372b40-680f-4d33-91bb-4e4915d0cdba"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("68b67f21-e6c9-471d-91bb-be6f09148f87"));

            migrationBuilder.DropColumn(
                name: "PaymentPurpose",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "payerAdress",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "payerIdentificationNumber",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "payerName",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "startingPricePerHectare",
                table: "Payments",
                newName: "realizedArea");

            migrationBuilder.RenameColumn(
                name: "publicBiddingDate",
                table: "Payments",
                newName: "startingTime");

            migrationBuilder.RenameColumn(
                name: "payerId",
                table: "Payments",
                newName: "buyerId");

            migrationBuilder.RenameColumn(
                name: "licitatedPrice",
                table: "Payments",
                newName: "banDuration");

            migrationBuilder.RenameColumn(
                name: "exception",
                table: "Payments",
                newName: "hasBan");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payments",
                newName: "endingTime");

            migrationBuilder.AddColumn<double>(
                name: "bestBid",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "bestBidder",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBanEnd",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dateOfBanStart",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "leasePeriod",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Plot",
                columns: table => new
                {
                    plotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plot", x => x.plotId);
                    table.ForeignKey(
                        name: "FK_Plot_Payments_paymentId",
                        column: x => x.paymentId,
                        principalTable: "Payments",
                        principalColumn: "paymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "exchangeRateId", "currencyCode", "currencyName", "currencyPrice" },
                values: new object[,]
                {
                    { new Guid("e3994763-cee5-434a-b124-4ca6c1410946"), "EUR", "EURO", 117.584 },
                    { new Guid("29c9ec79-ff5a-4b2c-8c52-39a933b75163"), "USD", "US Dollar", 103.298 },
                    { new Guid("f0b5a956-06d7-4334-8540-f73c7ed1d8bb"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("7d754c47-2700-4fbe-851c-3157c4d5c851"), "GBP", "Pound sterling", 139.73099999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plot_paymentId",
                table: "Plot",
                column: "paymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plot");

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("29c9ec79-ff5a-4b2c-8c52-39a933b75163"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("7d754c47-2700-4fbe-851c-3157c4d5c851"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("e3994763-cee5-434a-b124-4ca6c1410946"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("f0b5a956-06d7-4334-8540-f73c7ed1d8bb"));

            migrationBuilder.DropColumn(
                name: "bestBid",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "bestBidder",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "dateOfBanEnd",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "dateOfBanStart",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "leasePeriod",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "startingTime",
                table: "Payments",
                newName: "publicBiddingDate");

            migrationBuilder.RenameColumn(
                name: "realizedArea",
                table: "Payments",
                newName: "startingPricePerHectare");

            migrationBuilder.RenameColumn(
                name: "hasBan",
                table: "Payments",
                newName: "exception");

            migrationBuilder.RenameColumn(
                name: "endingTime",
                table: "Payments",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "buyerId",
                table: "Payments",
                newName: "payerId");

            migrationBuilder.RenameColumn(
                name: "banDuration",
                table: "Payments",
                newName: "licitatedPrice");

            migrationBuilder.AddColumn<string>(
                name: "PaymentPurpose",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "payerAdress",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "payerIdentificationNumber",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "payerName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "exchangeRateId", "currencyCode", "currencyName", "currencyPrice" },
                values: new object[,]
                {
                    { new Guid("5e372b40-680f-4d33-91bb-4e4915d0cdba"), "EUR", "EURO", 117.584 },
                    { new Guid("3dea0188-24be-480e-a053-5a6a4c98079c"), "USD", "US Dollar", 103.298 },
                    { new Guid("50f05730-9943-40c2-8574-d3d4ab0e1f46"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("68b67f21-e6c9-471d-91bb-be6f09148f87"), "GBP", "Pound sterling", 139.73099999999999 }
                });
        }
    }
}
