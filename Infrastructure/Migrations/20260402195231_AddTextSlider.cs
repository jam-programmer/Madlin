using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTextSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextOneSliderDownEn",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextOneSliderDownFa",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextOneSliderTopEn",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextOneSliderTopFa",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextThreeSliderDownEn",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextThreeSliderDownFa",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextThreeSliderTopEn",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextThreeSliderTopFa",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextTwoSliderDownEn",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextTwoSliderDownFa",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextTwoSliderTopEn",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextTwoSliderTopFa",
                schema: "Setting",
                table: "Header",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Setting",
                table: "Header",
                keyColumn: "Id",
                keyValue: new Guid("a1b4d3c4-e7f6-4a6b-8e5f-0e3f2b3b4c8d"),
                columns: new[] { "TextOneSliderDownEn", "TextOneSliderDownFa", "TextOneSliderTopEn", "TextOneSliderTopFa", "TextThreeSliderDownEn", "TextThreeSliderDownFa", "TextThreeSliderTopEn", "TextThreeSliderTopFa", "TextTwoSliderDownEn", "TextTwoSliderDownFa", "TextTwoSliderTopEn", "TextTwoSliderTopFa" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextOneSliderDownEn",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextOneSliderDownFa",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextOneSliderTopEn",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextOneSliderTopFa",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextThreeSliderDownEn",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextThreeSliderDownFa",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextThreeSliderTopEn",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextThreeSliderTopFa",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextTwoSliderDownEn",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextTwoSliderDownFa",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextTwoSliderTopEn",
                schema: "Setting",
                table: "Header");

            migrationBuilder.DropColumn(
                name: "TextTwoSliderTopFa",
                schema: "Setting",
                table: "Header");
        }
    }
}
