using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seo",
                schema: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OgTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgTypeFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgTypeEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgDescriptionFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterTitleFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterDescriptionFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Robots = table.Column<int>(type: "int", nullable: true),
                    ThemeColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeywordsEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeywordsFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Canonical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seo", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Setting",
                table: "Seo",
                columns: new[] { "Id", "Canonical", "Description", "KeywordsEn", "KeywordsFa", "OgDescriptionEn", "OgDescriptionFa", "OgImage", "OgTitleEn", "OgTitleFa", "OgTypeEn", "OgTypeFa", "OgUrl", "Robots", "ThemeColor", "Title", "TwitterDescriptionEn", "TwitterDescriptionFa", "TwitterImage", "TwitterTitleEn", "TwitterTitleFa" },
                values: new object[] { new Guid("c41ad831-7a86-4559-cd29-08de6c72b976"), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seo",
                schema: "Setting");
        }
    }
}
