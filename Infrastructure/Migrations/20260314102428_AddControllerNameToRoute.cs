using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddControllerNameToRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                schema: "dbo",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                column: "ControllerName",
                value: "ProductCategory");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("21f202f2-4f89-11d3-9a0c-0305e82c3301"),
                column: "ControllerName",
                value: "User");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
                column: "ControllerName",
                value: "Role");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8"),
                column: "ControllerName",
                value: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("7d444840-9dc0-11d1-b245-5ffdce74fad2"),
                column: "ControllerName",
                value: "Question");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("8c5e3f1a-9d5f-4b6a-8c7d-0e1f2a3b4c5d"),
                column: "ControllerName",
                value: "BlogCategory");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("9f8e7d6c-5b4a-3c2d-1e0f-123456789abc"),
                column: "ControllerName",
                value: "Tag");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "ControllerName",
                value: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("b6c7f8d9-e0a1-4b2c-8d3e-0f1a2b3c4d5e"),
                column: "ControllerName",
                value: "Blog");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c8d9e0f1-a2b3-4c5d-6e7f-8a9b0c1d2e3f"),
                column: "ControllerName",
                value: "Setting");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("e4d909c2-d4d8-4b6e-9b9d-1c3a4b5c6d7e"),
                column: "ControllerName",
                value: "Product");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                column: "ControllerName",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControllerName",
                schema: "dbo",
                table: "Route");
        }
    }
}
