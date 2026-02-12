using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITControl.Infrastructure.Shared.Migrations
{
    /// <inheritdoc />
    public partial class EquipmentsNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipments_Ip",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_Mac",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_Tag",
                table: "Equipments");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Equipments",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Mac",
                table: "Equipments",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Equipments",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Ip",
                table: "Equipments",
                column: "Ip",
                unique: true,
                filter: "[Ip] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Mac",
                table: "Equipments",
                column: "Mac",
                unique: true,
                filter: "[Mac] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Tag",
                table: "Equipments",
                column: "Tag",
                unique: true,
                filter: "[Tag] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipments_Ip",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_Mac",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_Tag",
                table: "Equipments");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Equipments",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mac",
                table: "Equipments",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Equipments",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Ip",
                table: "Equipments",
                column: "Ip",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Mac",
                table: "Equipments",
                column: "Mac",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_Tag",
                table: "Equipments",
                column: "Tag",
                unique: true);
        }
    }
}
