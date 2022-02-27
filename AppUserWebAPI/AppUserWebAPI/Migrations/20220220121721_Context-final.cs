using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppUserWebAPI.Migrations
{
    public partial class Contextfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    appUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    appUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appUserLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appUserUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appUserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeOfUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeOfUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.appUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
