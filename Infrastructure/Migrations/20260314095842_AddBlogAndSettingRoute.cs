using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogAndSettingRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[,]
                {
                    { new Guid("b6c7f8d9-e0a1-4b2c-8d3e-0f1a2b3c4d5e"), "", "مقالات", 14, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "", "/Admin/Blog/Index" },
                    { new Guid("c8d9e0f1-a2b3-4c5d-6e7f-8a9b0c1d2e3f"), "", "تنظیمات", 15, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "", "/Admin/Setting/General" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b6c7f8d9-e0a1-4b2c-8d3e-0f1a2b3c4d5e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c8d9e0f1-a2b3-4c5d-6e7f-8a9b0c1d2e3f"));
        }
    }
}
