using Microsoft.EntityFrameworkCore.Migrations;

namespace TAVI_Pavlodar.Migrations
{
    public partial class Loadiong3_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinutesForLoading",
                table: "Loadings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinutesForLoading",
                table: "Loadings");
        }
    }
}
