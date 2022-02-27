using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Migrations
{
    public partial class ChangedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plots");

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

            migrationBuilder.DropColumn(
                name: "banDuration",
                table: "Payments");

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
                name: "endingTime",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "hasBan",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "leasePeriod",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "realizedArea",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "startingTime",
                table: "Payments");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "banDuration",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<DateTime>(
                name: "endingTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "hasBan",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "leasePeriod",
                table: "Payments",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "realizedArea",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "startingTime",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    plotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    paymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    plot = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.plotId);
                    table.ForeignKey(
                        name: "FK_Plots_Payments_paymentId",
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
                    { new Guid("e84030f1-de4e-4fe6-b955-47be91a93e83"), "EUR", "EURO", 117.584 },
                    { new Guid("51a3727e-b756-4d0d-a3d5-cf230f4b0ee4"), "USD", "US Dollar", 103.298 },
                    { new Guid("782d8e54-15c2-419b-b97f-7eedf9334acb"), "CHF", "Swiss Franc", 111.33799999999999 },
                    { new Guid("fe607c65-fcd0-4874-b960-fba53af94fbf"), "GBP", "Pound sterling", 139.73099999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plots_paymentId",
                table: "Plots",
                column: "paymentId");
        }
    }
}
