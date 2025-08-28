using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Notifications2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CallId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TreatmentId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AppointmentId",
                table: "Notifications",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CallId",
                table: "Notifications",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TreatmentId",
                table: "Notifications",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Appointments_AppointmentId",
                table: "Notifications",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Calls_CallId",
                table: "Notifications",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Treatments_TreatmentId",
                table: "Notifications",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Appointments_AppointmentId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Calls_CallId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Treatments_TreatmentId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AppointmentId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CallId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TreatmentId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CallId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Notifications");
        }
    }
}
