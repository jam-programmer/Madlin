using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEnToFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "Product",
                table: "Feature",
                newName: "ValueFa");

            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "Product",
                table: "Feature",
                newName: "ValueEn");

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                schema: "Product",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleFa",
                schema: "Product",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleEn",
                schema: "Product",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "TitleFa",
                schema: "Product",
                table: "Feature");

            migrationBuilder.RenameColumn(
                name: "ValueFa",
                schema: "Product",
                table: "Feature",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "ValueEn",
                schema: "Product",
                table: "Feature",
                newName: "Title");
        }
    }
}
