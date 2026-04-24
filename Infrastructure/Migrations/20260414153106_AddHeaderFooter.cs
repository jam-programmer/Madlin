using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHeaderFooter : Migration
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
                defaultValue: new DateTime(2026, 4, 14, 8, 31, 6, 252, DateTimeKind.Local).AddTicks(1036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 11, 8, 44, 12, 492, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.AddColumn<string>(
                name: "Footer",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Setting",
                table: "General",
                keyColumn: "Id",
                keyValue: new Guid("c11cc931-7a86-4239-bd29-08de6c72b976"),
                columns: new[] { "Footer", "Header" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Footer",
                schema: "Setting",
                table: "General");

            migrationBuilder.DropColumn(
                name: "Header",
                schema: "Setting",
                table: "General");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 11, 8, 44, 12, 492, DateTimeKind.Local).AddTicks(5176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 14, 8, 31, 6, 252, DateTimeKind.Local).AddTicks(1036));
        }
    }
}
