using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerWebProject.API.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration1903 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PhoneNumber_PhoneNumberId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PhoneNumberId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumberId",
                table: "Customer");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "PhoneNumber",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_CustomerId",
                table: "PhoneNumber",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumber_Customer_CustomerId",
                table: "PhoneNumber",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_Customer_CustomerId",
                table: "PhoneNumber");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumber_CustomerId",
                table: "PhoneNumber");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PhoneNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "PhoneNumberId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PhoneNumberId",
                table: "Customer",
                column: "PhoneNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PhoneNumber_PhoneNumberId",
                table: "Customer",
                column: "PhoneNumberId",
                principalTable: "PhoneNumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
