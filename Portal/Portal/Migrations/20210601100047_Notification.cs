using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class Notification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_students_studentId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_teachers_Teacherid",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_studentId",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_Teacherid",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "Teacherid",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "personalNumber",
                table: "notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_notifications_personalNumber",
                table: "notifications",
                column: "personalNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_AspNetUsers_personalNumber",
                table: "notifications",
                column: "personalNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_AspNetUsers_personalNumber",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_personalNumber",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "personalNumber",
                table: "notifications");

            migrationBuilder.AddColumn<int>(
                name: "Teacherid",
                table: "notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_studentId",
                table: "notifications",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_Teacherid",
                table: "notifications",
                column: "Teacherid");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_students_studentId",
                table: "notifications",
                column: "studentId",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_teachers_Teacherid",
                table: "notifications",
                column: "Teacherid",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
