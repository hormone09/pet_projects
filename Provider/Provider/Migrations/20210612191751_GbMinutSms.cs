using Microsoft.EntityFrameworkCore.Migrations;

namespace Provider.Migrations
{
    public partial class GbMinutSms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GigabyteCount",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinuteCount",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SMSCount",
                table: "Rates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GigabyteCount",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "MinuteCount",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "SMSCount",
                table: "Rates");
        }
    }
}
