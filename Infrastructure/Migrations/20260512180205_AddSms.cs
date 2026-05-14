using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSms : Migration
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
                defaultValue: new DateTime(2026, 5, 12, 11, 2, 5, 13, DateTimeKind.Local).AddTicks(2255),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 9, 11, 8, 33, 199, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "ControllerName", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[] { new Guid("b4b8a8b1-a5d5-123b-5c5d-6c2c0c8a8a3e"), "Sms", "", "پیامک", 19, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "", "/Admin/Sms/Index" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b4b8a8b1-a5d5-123b-5c5d-6c2c0c8a8a3e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 9, 11, 8, 33, 199, DateTimeKind.Local).AddTicks(529),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 11, 2, 5, 13, DateTimeKind.Local).AddTicks(2255));
        }
    }
}
