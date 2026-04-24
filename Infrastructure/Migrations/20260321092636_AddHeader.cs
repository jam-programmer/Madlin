using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "ImageEntity");

            migrationBuilder.DropColumn(
                name: "TitleFa",
                table: "ImageEntity");

            migrationBuilder.CreateTable(
                name: "Header",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTextFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderTextEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GalleryTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Setting",
                table: "Header",
                columns: new[] { "Id", "BlogTitleEn", "BlogTitleFa", "CategoryTitleEn", "CategoryTitleFa", "GalleryTitleEn", "GalleryTitleFa", "ProductTitleEn", "ProductTitleFa", "SliderTextEn", "SliderTextFa", "SliderTitleEn", "SliderTitleFa" },
                values: new object[] { new Guid("a1b4d3c4-e7f6-4a6b-8e5f-0e3f2b3b4c8d"), "", "", "", "", "", "", "", "", "", "", "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Header",
                schema: "Setting");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "ImageEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleFa",
                table: "ImageEntity",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
