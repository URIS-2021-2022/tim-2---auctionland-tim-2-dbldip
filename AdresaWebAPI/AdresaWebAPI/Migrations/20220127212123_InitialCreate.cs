using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdresaWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    countryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.countryID);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "countryID", "countryName" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), "Serbia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
