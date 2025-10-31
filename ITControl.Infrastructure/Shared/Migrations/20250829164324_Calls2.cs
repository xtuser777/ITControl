﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITControl.Infrastructure.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Calls2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallsStatuses_Calls_CallId",
                table: "CallsStatuses");

            migrationBuilder.DropIndex(
                name: "IX_CallsStatuses_CallId",
                table: "CallsStatuses");

            migrationBuilder.DropColumn(
                name: "CallId",
                table: "CallsStatuses");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CallStatusId",
                table: "Calls",
                column: "CallStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_CallsStatuses_CallStatusId",
                table: "Calls",
                column: "CallStatusId",
                principalTable: "CallsStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_CallsStatuses_CallStatusId",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_CallStatusId",
                table: "Calls");

            migrationBuilder.AddColumn<Guid>(
                name: "CallId",
                table: "CallsStatuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CallsStatuses_CallId",
                table: "CallsStatuses",
                column: "CallId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CallsStatuses_Calls_CallId",
                table: "CallsStatuses",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
