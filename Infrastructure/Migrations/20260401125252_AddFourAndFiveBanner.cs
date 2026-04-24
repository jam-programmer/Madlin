using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFourAndFiveBanner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFivePath",
                schema: "dbo",
                table: "AdvertisingBanner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFourPath",
                schema: "dbo",
                table: "AdvertisingBanner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "AdvertisingBanner",
                keyColumn: "Id",
                keyValue: new Guid("a1b4c3d4-e7f6-4a6b-8c5d-0e3f2a3b4c5d"),
                columns: new[] { "ImageFivePath", "ImageFourPath" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFivePath",
                schema: "dbo",
                table: "AdvertisingBanner");

            migrationBuilder.DropColumn(
                name: "ImageFourPath",
                schema: "dbo",
                table: "AdvertisingBanner");
        }
    }
}
