using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGroupInRoute : Migration
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
                defaultValue: new DateTime(2026, 5, 13, 22, 36, 16, 483, DateTimeKind.Local).AddTicks(7489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 13, 22, 27, 5, 792, DateTimeKind.Local).AddTicks(6183));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b4b8a8b1-a5d5-123b-5c5d-6c2c0c8a8a3e"),
                columns: new[] { "ControllerName", "Order", "ParentId", "Url" },
                values: new object[] { "Bank", 41, new Guid("9cb8b710-9dad-12c4-60b4-00c05fd430c8"), "/Admin/Bank/Index" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "ControllerName", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[] { new Guid("9cb8b710-9dad-12c4-60b4-00c05fd430c8"), "", "<i class=\"icon ti-comment\"></i>", "سامانه پیامک", 40, new Guid("00000000-0000-0000-0000-000000000000"), "navigationSms", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("9cb8b710-9dad-12c4-60b4-00c05fd430c8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 13, 22, 27, 5, 792, DateTimeKind.Local).AddTicks(6183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 13, 22, 36, 16, 483, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b4b8a8b1-a5d5-123b-5c5d-6c2c0c8a8a3e"),
                columns: new[] { "ControllerName", "Order", "ParentId", "Url" },
                values: new object[] { "Sms", 19, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "/Admin/Sms/Index" });
        }
    }
}
