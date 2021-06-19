using Microsoft.EntityFrameworkCore.Migrations;

namespace TAVI_Pavlodar.Migrations
{
    public partial class Loading2_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Loadings_LoadingId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_LoadingId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "LoadingId",
                table: "BasketItems");

            migrationBuilder.CreateTable(
                name: "ProductsForLoading",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    desk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: false),
                    loadingId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsForLoading", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductsForLoading_Loadings_loadingId",
                        column: x => x.loadingId,
                        principalTable: "Loadings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsForLoading_loadingId",
                table: "ProductsForLoading",
                column: "loadingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsForLoading");

            migrationBuilder.AddColumn<string>(
                name: "LoadingId",
                table: "BasketItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_LoadingId",
                table: "BasketItems",
                column: "LoadingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Loadings_LoadingId",
                table: "BasketItems",
                column: "LoadingId",
                principalTable: "Loadings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
