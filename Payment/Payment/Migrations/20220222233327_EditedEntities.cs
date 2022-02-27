using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class EditedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("7ecc8a4c-1acf-453c-b6d6-e9cb11caf287"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("83980765-45c2-4a23-b021-dd732b79df1d"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("bdda5870-1b0b-44a1-916b-13b5806a39e1"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("df6c41aa-a098-4538-a4aa-cafe2e378e4c"));

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "exchangeRateId", "currencyCode", "currencyName", "currencyPrice" },
                values: new object[,]
                {
                    { new Guid("71c447cb-088a-4f1c-bb65-7ac53a4a510e"), "EUR", "EURO", 117.584 },
                    { new Guid("13626949-cb7e-4007-99ca-0946c17cb45a"), "USD", "US Dollar", 103.298 },
                    { new Guid("af0c9078-12fd-477f-8caf-b518ba3a7a10"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("bed1a976-8c86-4777-be20-272f51bce33b"), "GBP", "Pound sterling", 139.73099999999999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("13626949-cb7e-4007-99ca-0946c17cb45a"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("71c447cb-088a-4f1c-bb65-7ac53a4a510e"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("af0c9078-12fd-477f-8caf-b518ba3a7a10"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("bed1a976-8c86-4777-be20-272f51bce33b"));

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "exchangeRateId", "currencyCode", "currencyName", "currencyPrice" },
                values: new object[,]
                {
                    { new Guid("7ecc8a4c-1acf-453c-b6d6-e9cb11caf287"), "EUR", "EURO", 117.584 },
                    { new Guid("df6c41aa-a098-4538-a4aa-cafe2e378e4c"), "USD", "US Dollar", 103.298 },
                    { new Guid("83980765-45c2-4a23-b021-dd732b79df1d"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("bdda5870-1b0b-44a1-916b-13b5806a39e1"), "GBP", "Pound sterling", 139.73099999999999 }
                });
        }
    }
}
