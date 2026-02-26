using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUrlNameProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCode",
                schema: "Product",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                schema: "Product",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MainImagePath",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "default.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "default.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "HoverImagePath",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "default.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "default.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "FullDescriptionFa",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullDescriptionEn",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UrlName",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCode",
                schema: "Product",
                table: "Product",
                column: "ProductCode",
                unique: true,
                filter: "[ProductCode] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_ProductCode",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UrlName",
                schema: "Product",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                schema: "Product",
                table: "Product",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainImagePath",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "default.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "default.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "HoverImagePath",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "default.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "default.jpg");

            migrationBuilder.AlterColumn<string>(
                name: "FullDescriptionFa",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullDescriptionEn",
                schema: "Product",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCode",
                schema: "Product",
                table: "Product",
                column: "ProductCode",
                unique: true);
        }
    }
}
