using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEnFromTypeOg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OgTypeEn",
                schema: "Setting",
                table: "Seo");

            migrationBuilder.RenameColumn(
                name: "OgTypeFa",
                schema: "Setting",
                table: "Seo",
                newName: "OgType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OgType",
                schema: "Setting",
                table: "Seo",
                newName: "OgTypeFa");

            migrationBuilder.AddColumn<string>(
                name: "OgTypeEn",
                schema: "Setting",
                table: "Seo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Setting",
                table: "Seo",
                keyColumn: "Id",
                keyValue: new Guid("c41ad831-7a86-4559-cd29-08de6c72b976"),
                column: "OgTypeEn",
                value: null);
        }
    }
}
