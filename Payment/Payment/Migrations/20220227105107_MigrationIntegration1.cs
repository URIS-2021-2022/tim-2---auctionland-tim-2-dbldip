using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class MigrationIntegration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("6c6d6616-b3ca-4086-af22-5521ecd38e04"), "EUR", "EURO", 117.584 },
                    { new Guid("cd666fc1-0dbd-4e5a-958b-310f7239be7e"), "USD", "US Dollar", 103.298 },
                    { new Guid("1ea830d2-980e-4566-a0f2-34944b6d1f34"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("a7a12b65-e27b-4c94-87f6-71acf19ba8e0"), "GBP", "Pound sterling", 139.73099999999999 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("1ea830d2-980e-4566-a0f2-34944b6d1f34"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("6c6d6616-b3ca-4086-af22-5521ecd38e04"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("a7a12b65-e27b-4c94-87f6-71acf19ba8e0"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("cd666fc1-0dbd-4e5a-958b-310f7239be7e"));

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
    }
}
