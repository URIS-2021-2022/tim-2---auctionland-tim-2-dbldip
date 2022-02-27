using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiceWebAPI.Migrations
{
    public partial class UpdateMigratinLic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FizickaLica",
                keyColumn: "LiceId",
                keyValue: new Guid("05b6200f-d5ac-4dce-93e6-9cd5942831a3"),
                column: "Jmbg",
                value: "1253627363526");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FizickaLica",
                keyColumn: "LiceId",
                keyValue: new Guid("05b6200f-d5ac-4dce-93e6-9cd5942831a3"),
                column: "Jmbg",
                value: null);
        }
    }
}
