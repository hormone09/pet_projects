﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Provider.Migrations
{
    public partial class DeleteApplicate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicates", x => x.Id);
                });
        }
    }
}
