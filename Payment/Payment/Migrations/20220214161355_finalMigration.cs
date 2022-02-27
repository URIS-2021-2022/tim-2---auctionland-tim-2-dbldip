using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class finalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentServices",
                table: "PaymentServices");

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("0bc832c3-5e95-49fc-a8d4-fb7780615efd"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("25c03215-b093-43cb-ba76-30d1d51fd7c6"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("3ac939a6-cf23-472e-b829-ebd8c9c8f890"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("d2391865-62a4-4172-b485-23930645055a"));

            migrationBuilder.RenameTable(
                name: "PaymentServices",
                newName: "Payments");

            migrationBuilder.RenameColumn(
                name: "PaymentServicePurpose",
                table: "Payments",
                newName: "PaymentPurpose");

            migrationBuilder.RenameColumn(
                name: "PaymentServiceDate",
                table: "Payments",
                newName: "PaymentDate");

            migrationBuilder.RenameColumn(
                name: "PaymentServiceId",
                table: "Payments",
                newName: "paymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "paymentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

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

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "PaymentServices");

            migrationBuilder.RenameColumn(
                name: "PaymentPurpose",
                table: "PaymentServices",
                newName: "PaymentServicePurpose");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "PaymentServices",
                newName: "PaymentServiceDate");

            migrationBuilder.RenameColumn(
                name: "paymentId",
                table: "PaymentServices",
                newName: "PaymentServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentServices",
                table: "PaymentServices",
                column: "PaymentServiceId");

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
    }
}
