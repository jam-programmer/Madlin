using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteNewsletter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("a4d4a0f1-e5f6-4a7b-8c9d-6a7b0c4b2a3f"),
                column: "Order",
                value: 18);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d4a0f1-a2b3-4b3d-6e5f-6a4b0c4b2e3f"),
                column: "Order",
                value: 17);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "ControllerName", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[] { new Guid("f4d2a0f1-a5d1-5a7b-3c9d-6a7b0c7e2a3e"), "Newsletter", "", "خبرنامه", 19, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "", "/Admin/Newsletter/Index" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("f4d2a0f1-a5d1-5a7b-3c9d-6a7b0c7e2a3e"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("a4d4a0f1-e5f6-4a7b-8c9d-6a7b0c4b2a3f"),
                column: "Order",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d4a0f1-a2b3-4b3d-6e5f-6a4b0c4b2e3f"),
                column: "Order",
                value: 16);
        }
    }
}
