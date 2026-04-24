using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeoEn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Setting",
                table: "Seo",
                newName: "TitleFa");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Setting",
                table: "Seo",
                newName: "TitleEn");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                schema: "Setting",
                table: "Seo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionFa",
                schema: "Setting",
                table: "Seo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Setting",
                table: "Seo",
                keyColumn: "Id",
                keyValue: new Guid("c41ad831-7a86-4559-cd29-08de6c72b976"),
                columns: new[] { "DescriptionEn", "DescriptionFa" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                schema: "Setting",
                table: "Seo");

            migrationBuilder.DropColumn(
                name: "DescriptionFa",
                schema: "Setting",
                table: "Seo");

            migrationBuilder.RenameColumn(
                name: "TitleFa",
                schema: "Setting",
                table: "Seo",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEn",
                schema: "Setting",
                table: "Seo",
                newName: "Description");
        }
    }
}
