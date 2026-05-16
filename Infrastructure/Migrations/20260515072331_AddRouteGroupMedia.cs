using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRouteGroupMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 15, 0, 23, 30, 783, DateTimeKind.Local).AddTicks(5970),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 14, 7, 3, 2, 801, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c2c7a9f1-a5d5-424b-2c2d-6c2c0c2e2a3e"),
                columns: new[] { "Order", "ParentId" },
                values: new object[] { 53, new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d4a0f1-a2b3-4b3d-6e5f-6a4b0c4b2e3f"),
                columns: new[] { "Order", "ParentId" },
                values: new object[] { 52, new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d6e0f1-a0b3-4c5d-6e5f-8a1b0c4d2e3f"),
                columns: new[] { "Order", "ParentId" },
                values: new object[] { 51, new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8") });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "ControllerName", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[,]
                {
                    { new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8"), "", "<i class=\"icon ti-gallery\"></i>", "رسانه", 50, new Guid("00000000-0000-0000-0000-000000000000"), "navigationSms", "" },
                    { new Guid("c3c3a3f3-a5d5-424a-5c5d-7c7c0c9e2a9c"), "Event", "", "رویداد ها", 54, new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8"), "", "/Admin/Event/Index" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3c3a3f3-a5d5-424a-5c5d-7c7c0c9e2a9c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 14, 7, 3, 2, 801, DateTimeKind.Local).AddTicks(3265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 15, 0, 23, 30, 783, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c2c7a9f1-a5d5-424b-2c2d-6c2c0c2e2a3e"),
                columns: new[] { "Order", "ParentId" },
                values: new object[] { 19, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d4a0f1-a2b3-4b3d-6e5f-6a4b0c4b2e3f"),
                columns: new[] { "Order", "ParentId" },
                values: new object[] { 17, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d") });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c3d6e0f1-a0b3-4c5d-6e5f-8a1b0c4d2e3f"),
                columns: new[] { "Order", "ParentId" },
                values: new object[] { 16, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d") });
        }
    }
}
