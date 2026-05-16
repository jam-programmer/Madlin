using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSmsRoute : Migration
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
                defaultValue: new DateTime(2026, 5, 14, 7, 3, 2, 801, DateTimeKind.Local).AddTicks(3265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 13, 22, 47, 39, 640, DateTimeKind.Local).AddTicks(6231));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "ControllerName", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[] { new Guid("b5b5a5b7-a5d5-123b-5c5d-6c2c4c8a8a4a"), "Sms", "", "ارسال پیامک", 42, new Guid("9cb8b710-9dad-12c4-60b4-00c05fd430c8"), "", "/Admin/Sms/Index" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b5b5a5b7-a5d5-123b-5c5d-6c2c4c8a8a4a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 13, 22, 47, 39, 640, DateTimeKind.Local).AddTicks(6231),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 14, 7, 3, 2, 801, DateTimeKind.Local).AddTicks(3265));
        }
    }
}
