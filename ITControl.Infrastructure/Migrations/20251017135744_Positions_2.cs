using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Positions_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Positions",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_Description",
                table: "Positions",
                newName: "IX_Positions_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Positions",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                newName: "IX_Positions_Description");
        }
    }
}
