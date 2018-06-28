using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShoppingCartASP.Data.Migrations
{
    public partial class products3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product_code",
                table: "Products",
                newName: "ProductCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCode",
                table: "Products",
                newName: "Product_code");
        }
    }
}
