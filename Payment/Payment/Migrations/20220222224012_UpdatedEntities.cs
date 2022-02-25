using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class UpdatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("15f7392c-d099-48bc-afcb-36ca3ed30c6f"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("3ca3cbbe-cd96-48ff-afef-eca304e3c879"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("6a92ded7-9994-4417-9727-6101e2508b45"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("885d2166-d12a-4483-8499-4de05421c8ca"));

            migrationBuilder.DropColumn(
                name: "currencyCode",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "currencyName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Payments");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "currencyCode",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "currencyName",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "Payments",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "exchangeRateId", "currencyCode", "currencyName", "currencyPrice" },
                values: new object[,]
                {
                    { new Guid("3ca3cbbe-cd96-48ff-afef-eca304e3c879"), "EUR", "EURO", 117.584 },
                    { new Guid("6a92ded7-9994-4417-9727-6101e2508b45"), "USD", "US Dollar", 103.298 },
                    { new Guid("15f7392c-d099-48bc-afcb-36ca3ed30c6f"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("885d2166-d12a-4483-8499-4de05421c8ca"), "GBP", "Pound sterling", 139.73099999999999 }
                });
        }
    }
}
