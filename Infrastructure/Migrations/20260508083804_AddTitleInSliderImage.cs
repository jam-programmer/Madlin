using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleInSliderImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "SliderImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 8, 1, 38, 3, 708, DateTimeKind.Local).AddTicks(9953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 8, 0, 56, 1, 988, DateTimeKind.Local).AddTicks(8893));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "SliderImage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 8, 0, 56, 1, 988, DateTimeKind.Local).AddTicks(8893),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 8, 1, 38, 3, 708, DateTimeKind.Local).AddTicks(9953));
        }
    }
}
