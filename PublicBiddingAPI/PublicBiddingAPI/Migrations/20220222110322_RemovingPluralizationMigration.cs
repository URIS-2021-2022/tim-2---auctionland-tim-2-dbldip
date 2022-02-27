using Microsoft.EntityFrameworkCore.Migrations;

namespace PublicBiddingAPI.Migrations
{
    public partial class RemovingPluralizationMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicBiddings_CadastralMunicipality_cadastralMunicipalitycadastralMuniciplaityId",
                table: "PublicBiddings");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicBiddings_TypesOfPublicBidding_typeOfPublicBiddingId",
                table: "PublicBiddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicBiddings",
                table: "PublicBiddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plots",
                table: "Plots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bidders",
                table: "Bidders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BestBidders",
                table: "BestBidders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppliedBuyers",
                table: "AppliedBuyers");

            migrationBuilder.RenameTable(
                name: "PublicBiddings",
                newName: "PublicBidding");

            migrationBuilder.RenameTable(
                name: "Plots",
                newName: "Plot");

            migrationBuilder.RenameTable(
                name: "Bidders",
                newName: "Bidder");

            migrationBuilder.RenameTable(
                name: "BestBidders",
                newName: "BestBidder");

            migrationBuilder.RenameTable(
                name: "AppliedBuyers",
                newName: "AppliedBuyer");

            migrationBuilder.RenameIndex(
                name: "IX_PublicBiddings_typeOfPublicBiddingId",
                table: "PublicBidding",
                newName: "IX_PublicBidding_typeOfPublicBiddingId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicBiddings_cadastralMunicipalitycadastralMuniciplaityId",
                table: "PublicBidding",
                newName: "IX_PublicBidding_cadastralMunicipalitycadastralMuniciplaityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicBidding",
                table: "PublicBidding",
                column: "publicBiddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plot",
                table: "Plot",
                column: "plotConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bidder",
                table: "Bidder",
                column: "bidderConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BestBidder",
                table: "BestBidder",
                column: "bestBidderConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppliedBuyer",
                table: "AppliedBuyer",
                column: "buyerConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicBidding_CadastralMunicipality_cadastralMunicipalitycadastralMuniciplaityId",
                table: "PublicBidding",
                column: "cadastralMunicipalitycadastralMuniciplaityId",
                principalTable: "CadastralMunicipality",
                principalColumn: "cadastralMuniciplaityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicBidding_TypesOfPublicBidding_typeOfPublicBiddingId",
                table: "PublicBidding",
                column: "typeOfPublicBiddingId",
                principalTable: "TypesOfPublicBidding",
                principalColumn: "typeOfPublicBiddingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicBidding_CadastralMunicipality_cadastralMunicipalitycadastralMuniciplaityId",
                table: "PublicBidding");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicBidding_TypesOfPublicBidding_typeOfPublicBiddingId",
                table: "PublicBidding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PublicBidding",
                table: "PublicBidding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plot",
                table: "Plot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bidder",
                table: "Bidder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BestBidder",
                table: "BestBidder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppliedBuyer",
                table: "AppliedBuyer");

            migrationBuilder.RenameTable(
                name: "PublicBidding",
                newName: "PublicBiddings");

            migrationBuilder.RenameTable(
                name: "Plot",
                newName: "Plots");

            migrationBuilder.RenameTable(
                name: "Bidder",
                newName: "Bidders");

            migrationBuilder.RenameTable(
                name: "BestBidder",
                newName: "BestBidders");

            migrationBuilder.RenameTable(
                name: "AppliedBuyer",
                newName: "AppliedBuyers");

            migrationBuilder.RenameIndex(
                name: "IX_PublicBidding_typeOfPublicBiddingId",
                table: "PublicBiddings",
                newName: "IX_PublicBiddings_typeOfPublicBiddingId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicBidding_cadastralMunicipalitycadastralMuniciplaityId",
                table: "PublicBiddings",
                newName: "IX_PublicBiddings_cadastralMunicipalitycadastralMuniciplaityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PublicBiddings",
                table: "PublicBiddings",
                column: "publicBiddingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plots",
                table: "Plots",
                column: "plotConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bidders",
                table: "Bidders",
                column: "bidderConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BestBidders",
                table: "BestBidders",
                column: "bestBidderConnectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppliedBuyers",
                table: "AppliedBuyers",
                column: "buyerConnectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicBiddings_CadastralMunicipality_cadastralMunicipalitycadastralMuniciplaityId",
                table: "PublicBiddings",
                column: "cadastralMunicipalitycadastralMuniciplaityId",
                principalTable: "CadastralMunicipality",
                principalColumn: "cadastralMuniciplaityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicBiddings_TypesOfPublicBidding_typeOfPublicBiddingId",
                table: "PublicBiddings",
                column: "typeOfPublicBiddingId",
                principalTable: "TypesOfPublicBidding",
                principalColumn: "typeOfPublicBiddingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
