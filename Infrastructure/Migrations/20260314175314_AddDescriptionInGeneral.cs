using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionInGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionFa",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Setting",
                table: "General",
                keyColumn: "Id",
                keyValue: new Guid("c11cc931-7a86-4239-bd29-08de6c72b976"),
                columns: new[] { "DescriptionEn", "DescriptionFa" },
                values: new object[] { "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                schema: "Setting",
                table: "General");

            migrationBuilder.DropColumn(
                name: "DescriptionFa",
                schema: "Setting",
                table: "General");
        }
    }
}
