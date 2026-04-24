using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRulesToGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegistrationRulesEn",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationRulesFa",
                schema: "Setting",
                table: "General",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Setting",
                table: "General",
                keyColumn: "Id",
                keyValue: new Guid("c11cc931-7a86-4239-bd29-08de6c72b976"),
                columns: new[] { "RegistrationRulesEn", "RegistrationRulesFa" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationRulesEn",
                schema: "Setting",
                table: "General");

            migrationBuilder.DropColumn(
                name: "RegistrationRulesFa",
                schema: "Setting",
                table: "General");
        }
    }
}
