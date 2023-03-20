using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerWebProject.API.Migrations
{
    /// <inheritdoc />
    public partial class Removingtablecontactmode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_ContactMode_ContactModeId",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "ContactMode");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ContactModeId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ContactModeId",
                table: "Customer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContactModeId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ContactMode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMode", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ContactModeId",
                table: "Customer",
                column: "ContactModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_ContactMode_ContactModeId",
                table: "Customer",
                column: "ContactModeId",
                principalTable: "ContactMode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
