using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Route",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniqueId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Route",
                columns: new[] { "Id", "Icon", "Name", "Order", "UniqueId", "Url" },
                values: new object[,]
                {
                    { new Guid("01234567-89ab-cdef-0123-456789abcdef"), "", "دسته بندی محصولات", 21, "", "/Admin/ProductCategory/Index" },
                    { new Guid("21f202f2-4f89-11d3-9a0c-0305e82c3301"), "", "کاربران", 32, "", "/Admin/User/Index" },
                    { new Guid("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), "", "‌نقش های کاربری", 31, "", "/Admin/Role/Index" },
                    { new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8"), "<i class=\"icon ti-user\"></i>", "مدیریت کاربران", 30, "navigationUser", "" },
                    { new Guid("7d444840-9dc0-11d1-b245-5ffdce74fad2"), "", "سوالات متداول", 11, "", "/Admin/Question/Index" },
                    { new Guid("8c5e3f1a-9d5f-4b6a-8c7d-0e1f2a3b4c5d"), "", "دسته بندی مقالات", 12, "", "/Admin/BlogCategory/Index" },
                    { new Guid("9f8e7d6c-5b4a-3c2d-1e0f-123456789abc"), "", "برچسب ها", 13, "", "/Admin/Tag/Index" },
                    { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), "<i class=\"icon ti-layers\"></i>", "اطلاعات پایه", 10, "navigationBase", "" },
                    { new Guid("e4d909c2-d4d8-4b6e-9b9d-1c3a4b5c6d7e"), "", "محصولات", 22, "", "/Admin/Product/Index" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "<i class=\"icon ti-package\"></i>", "مدیریت محصولات", 20, "navigationProduct", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Route",
                schema: "dbo");
        }
    }
}
