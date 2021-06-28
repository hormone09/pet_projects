using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastVisit",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "lastVisit",
                table: "students");

            migrationBuilder.CreateTable(
                name: "userImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullPuth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_userImages_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userImages_userId",
                table: "userImages",
                column: "userId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userImages");

            migrationBuilder.AddColumn<DateTime>(
                name: "lastVisit",
                table: "teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "lastVisit",
                table: "students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
