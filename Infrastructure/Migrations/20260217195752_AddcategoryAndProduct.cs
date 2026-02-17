using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddcategoryAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TitleFa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: false),
                    DescriptionFa = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: false),
                    MainImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "default.jpg"),
                    IconImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "default_icon.jpg"),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ParentProductCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentProductCategoryId",
                        column: x => x.ParentProductCategoryId,
                        principalSchema: "Product",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TitleFa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MainImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "default.jpg"),
                    HoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "default.jpg"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    ShortDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescriptionFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullDescriptionFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Product",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentProductCategoryId",
                schema: "Product",
                table: "Category",
                column: "ParentProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "Product",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCode",
                schema: "Product",
                table: "Product",
                column: "ProductCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Product");
        }
    }
}
