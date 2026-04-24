using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBanners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisingBanner",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTwo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisingBanner", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AdvertisingBanner",
                columns: new[] { "Id", "ImageOne", "ImageTwo" },
                values: new object[] { new Guid("a1b4c3d4-e7f6-4a6b-8c5d-0e3f2a3b4c5d"), "default.jpg", "default.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisingBanner",
                schema: "dbo");
        }
    }
}
