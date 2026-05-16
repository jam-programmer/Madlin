using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMediaGroup : Migration
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
                defaultValue: new DateTime(2026, 5, 15, 0, 25, 56, 908, DateTimeKind.Local).AddTicks(5860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 15, 0, 23, 30, 783, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8"),
                column: "UniqueId",
                value: "navigationMedia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2026, 5, 15, 0, 25, 56, 908, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("1cb1b110-9bab-12c1-10c4-00c05fc430c8"),
                column: "UniqueId",
                value: "navigationSms");
        }
    }
}
