using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicBiddingAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfPublicBidding",
                columns: table => new
                {
                    typeOfPublicBiddingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeOfPublicBiddingName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfPublicBidding", x => x.typeOfPublicBiddingId);
                });

            migrationBuilder.InsertData(
                table: "TypesOfPublicBidding",
                columns: new[] { "typeOfPublicBiddingId", "typeOfPublicBiddingName" },
                values: new object[] { new Guid("db2e9db5-16f1-447b-8c6d-3ffcc0277afb"), "Javno nadmetanje" });

            migrationBuilder.InsertData(
                table: "TypesOfPublicBidding",
                columns: new[] { "typeOfPublicBiddingId", "typeOfPublicBiddingName" },
                values: new object[] { new Guid("7d4d747d-e7af-4702-8e4a-cefbf69beccd"), "Otvaranje zatvorenih ponuda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypesOfPublicBidding");
        }
    }
}
