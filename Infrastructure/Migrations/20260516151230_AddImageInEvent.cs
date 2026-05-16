using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageInEvent : Migration
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
                defaultValue: new DateTime(2026, 5, 16, 8, 12, 29, 570, DateTimeKind.Local).AddTicks(983),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 15, 0, 45, 44, 678, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.AddColumn<string>(
                name: "Path",
                schema: "dbo",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                schema: "dbo",
                table: "Event");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 15, 0, 45, 44, 678, DateTimeKind.Local).AddTicks(4384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 16, 8, 12, 29, 570, DateTimeKind.Local).AddTicks(983));
        }
    }
}
