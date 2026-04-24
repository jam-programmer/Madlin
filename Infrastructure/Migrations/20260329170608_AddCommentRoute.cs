using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "ControllerName", "Icon", "Name", "Order", "ParentId", "UniqueId", "Url" },
                values: new object[] { new Guid("c6b909c2-d6d8-4b6e-7b2d-1c3a3b8c6d1e"), "Product", "", "دیدگاه ها", 23, new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "", "/Admin/Comment/Index" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Route",
                keyColumn: "Id",
                keyValue: new Guid("c6b909c2-d6d8-4b6e-7b2d-1c3a3b8c6d1e"));
        }
    }
}
