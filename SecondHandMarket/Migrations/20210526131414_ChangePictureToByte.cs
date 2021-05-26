using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondHandMarket.Migrations
{
    public partial class ChangePictureToByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicPath",
                table: "Pictures");

            migrationBuilder.AddColumn<byte[]>(
                name: "PicInByte",
                table: "Pictures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicInByte",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "PicPath",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
