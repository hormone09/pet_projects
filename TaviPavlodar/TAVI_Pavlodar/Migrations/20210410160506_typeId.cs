using Microsoft.EntityFrameworkCore.Migrations;

namespace TAVI_Pavlodar.Migrations
{
    public partial class typeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "typeId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typeId",
                table: "BasketItems");
        }
    }
}
