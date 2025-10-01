using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Divisions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Users_UserId",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_UserId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Divisions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Divisions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_UserId",
                table: "Divisions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Users_UserId",
                table: "Divisions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
