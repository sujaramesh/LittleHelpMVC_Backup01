using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LittleHelpMVC.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Helpers");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Helpers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Helpers_CategoryID",
                table: "Helpers",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Helpers_Categories_CategoryID",
                table: "Helpers",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Helpers_Categories_CategoryID",
                table: "Helpers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Helpers_CategoryID",
                table: "Helpers");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Helpers");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Helpers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
