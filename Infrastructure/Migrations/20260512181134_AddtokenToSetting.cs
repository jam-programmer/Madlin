using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddtokenToSetting : Migration
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
                defaultValue: new DateTime(2026, 5, 12, 11, 11, 34, 21, DateTimeKind.Local).AddTicks(4690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 11, 2, 5, 13, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.AddColumn<string>(
                name: "ExclusiveNumber",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmsToken",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Setting",
                table: "General",
                keyColumn: "Id",
                keyValue: new Guid("c11cc931-7a86-4239-bd29-08de6c72b976"),
                columns: new[] { "ExclusiveNumber", "SmsToken" },
                values: new object[] { "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExclusiveNumber",
                schema: "Setting",
                table: "General");

            migrationBuilder.DropColumn(
                name: "SmsToken",
                schema: "Setting",
                table: "General");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 12, 11, 2, 5, 13, DateTimeKind.Local).AddTicks(2255),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 11, 11, 34, 21, DateTimeKind.Local).AddTicks(4690));
        }
    }
}
