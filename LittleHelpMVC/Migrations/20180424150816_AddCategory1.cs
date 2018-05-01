using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LittleHelpMVC.Migrations
{
    public partial class AddCategory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helpers_Categories_CategoryID",
                table: "Helpers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Helpers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Helpers_Categories_CategoryID",
                table: "Helpers",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helpers_Categories_CategoryID",
                table: "Helpers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Helpers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Helpers_Categories_CategoryID",
                table: "Helpers",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
