using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBannerRouteName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d6e0f1-a0b3-4c5d-6e5f-8a1b0c4d2e3f"),
                column: "Url",
                value: "/Admin/Setting/AdvertisingBanner");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d6e0f1-a0b3-4c5d-6e5f-8a1b0c4d2e3f"),
                column: "Url",
                value: "/Admin/Setting/Banner");
        }
    }
}
