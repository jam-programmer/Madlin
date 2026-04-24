using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShowSlider",
                schema: "Product",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageThreePath",
                schema: "dbo",
                table: "AdvertisingBanner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AdvertisingBanner",
                keyColumn: "Id",
                keyValue: new Guid("a1b4c3d4-e7f6-4a6b-8c5d-0e3f2a3b4c5d"),
                column: "ImageThreePath",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShowSlider",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageThreePath",
                schema: "dbo",
                table: "AdvertisingBanner");
        }
    }
}
