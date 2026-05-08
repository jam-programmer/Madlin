using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateAtToSliderImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "SliderImage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 8, 0, 56, 1, 988, DateTimeKind.Local).AddTicks(8893),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 8, 0, 50, 37, 370, DateTimeKind.Local).AddTicks(429));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "SliderImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 8, 0, 50, 37, 370, DateTimeKind.Local).AddTicks(429),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 8, 0, 56, 1, 988, DateTimeKind.Local).AddTicks(8893));
        }
    }
}
