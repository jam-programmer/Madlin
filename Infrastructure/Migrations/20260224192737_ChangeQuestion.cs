using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                schema: "dbo",
                table: "Question",
                newName: "TitleFa");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "dbo",
                table: "Question",
                newName: "TitleEn");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                schema: "dbo",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionFa",
                schema: "dbo",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TitleFa",
                schema: "Product",
                table: "Category",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                schema: "Product",
                table: "Category",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionFa",
                schema: "Product",
                table: "Category",
                type: "nvarchar(max)",
                maxLength: 6000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 6000);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionEn",
                schema: "Product",
                table: "Category",
                type: "nvarchar(max)",
                maxLength: 6000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 6000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                schema: "dbo",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "DescriptionFa",
                schema: "dbo",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "TitleFa",
                schema: "dbo",
                table: "Question",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEn",
                schema: "dbo",
                table: "Question",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "TitleFa",
                schema: "Product",
                table: "Category",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TitleEn",
                schema: "Product",
                table: "Category",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionFa",
                schema: "Product",
                table: "Category",
                type: "nvarchar(max)",
                maxLength: 6000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 6000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionEn",
                schema: "Product",
                table: "Category",
                type: "nvarchar(max)",
                maxLength: 6000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 6000,
                oldNullable: true);
        }
    }
}
