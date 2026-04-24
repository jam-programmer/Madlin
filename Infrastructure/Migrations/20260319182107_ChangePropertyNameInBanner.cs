using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyNameInBanner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageTwo",
                schema: "dbo",
                table: "AdvertisingBanner",
                newName: "ImageTwoPath");

            migrationBuilder.RenameColumn(
                name: "ImageOne",
                schema: "dbo",
                table: "AdvertisingBanner",
                newName: "ImageOnePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageTwoPath",
                schema: "dbo",
                table: "AdvertisingBanner",
                newName: "ImageTwo");

            migrationBuilder.RenameColumn(
                name: "ImageOnePath",
                schema: "dbo",
                table: "AdvertisingBanner",
                newName: "ImageOne");
        }
    }
}
