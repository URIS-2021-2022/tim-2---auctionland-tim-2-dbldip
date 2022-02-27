using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class AddedPlots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plot_Payments_paymentId",
                table: "Plot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plot",
                table: "Plot");

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

            migrationBuilder.RenameTable(
                name: "Plot",
                newName: "Plots");

            migrationBuilder.RenameIndex(
                name: "IX_Plot_paymentId",
                table: "Plots",
                newName: "IX_Plots_paymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plots",
                table: "Plots",
                column: "plotId");

            migrationBuilder.InsertData(
                table: "ExchangeRates",
                columns: new[] { "exchangeRateId", "currencyCode", "currencyName", "currencyPrice" },
                values: new object[,]
                {
                    { new Guid("e84030f1-de4e-4fe6-b955-47be91a93e83"), "EUR", "EURO", 117.584 },
                    { new Guid("51a3727e-b756-4d0d-a3d5-cf230f4b0ee4"), "USD", "US Dollar", 103.298 },
                    { new Guid("782d8e54-15c2-419b-b97f-7eedf9334acb"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("fe607c65-fcd0-4874-b960-fba53af94fbf"), "GBP", "Pound sterling", 139.73099999999999 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Plots_Payments_paymentId",
                table: "Plots",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plots_Payments_paymentId",
                table: "Plots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plots",
                table: "Plots");

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("51a3727e-b756-4d0d-a3d5-cf230f4b0ee4"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("782d8e54-15c2-419b-b97f-7eedf9334acb"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("e84030f1-de4e-4fe6-b955-47be91a93e83"));

            migrationBuilder.DeleteData(
                table: "ExchangeRates",
                keyColumn: "exchangeRateId",
                keyValue: new Guid("fe607c65-fcd0-4874-b960-fba53af94fbf"));

            migrationBuilder.RenameTable(
                name: "Plots",
                newName: "Plot");

            migrationBuilder.RenameIndex(
                name: "IX_Plots_paymentId",
                table: "Plot",
                newName: "IX_Plot_paymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plot",
                table: "Plot",
                column: "plotId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Plot_Payments_paymentId",
                table: "Plot",
                column: "paymentId",
                principalTable: "Payments",
                principalColumn: "paymentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
