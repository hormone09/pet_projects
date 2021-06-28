using Microsoft.EntityFrameworkCore.Migrations;

namespace Portal.Migrations
{
    public partial class Image2_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgPath",
                table: "teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imgPath",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgPath",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "imgPath",
                table: "students");
        }
    }
}
