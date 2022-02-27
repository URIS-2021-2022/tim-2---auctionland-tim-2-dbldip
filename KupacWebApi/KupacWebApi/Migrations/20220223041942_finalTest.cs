using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KupacWebApi.Migrations
{
    public partial class finalTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizedPeopleBuyers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizedPeopleBuyers",
                columns: table => new
                {
                    authorizedPersonBuyerConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    authorizedPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizedPeopleBuyers", x => x.authorizedPersonBuyerConnectionId);
                });
        }
    }
}
