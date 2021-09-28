using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHandMarket.Migrations
{
    public partial class removeAppuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_SubLocations_SubLocationId",
                table: "Advertisements");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_SubLocations_SubLocationId",
                table: "Advertisements",
                column: "SubLocationId",
                principalTable: "SubLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_SubLocations_SubLocationId",
                table: "Advertisements");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_SubLocations_SubLocationId",
                table: "Advertisements",
                column: "SubLocationId",
                principalTable: "SubLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
