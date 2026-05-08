using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSlider : Migration
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
                defaultValue: new DateTime(2026, 5, 8, 0, 50, 37, 370, DateTimeKind.Local).AddTicks(429),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 17, 3, 42, 27, 908, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.CreateTable(
                name: "SliderImage",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImage", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "ControllerName", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[] { new Guid("c2c7a9f1-a5d5-424b-2c2d-6c2c0c2e2a3e"), "Slider", "", "اسلایدر", 19, new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "", "/Admin/Slider/Index" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderImage",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c2c7a9f1-a5d5-424b-2c2d-6c2c0c2e2a3e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 17, 3, 42, 27, 908, DateTimeKind.Local).AddTicks(8162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 8, 0, 50, 37, 370, DateTimeKind.Local).AddTicks(429));
        }
    }
}
