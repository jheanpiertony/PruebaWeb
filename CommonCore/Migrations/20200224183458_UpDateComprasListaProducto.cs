using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonCore.Migrations
{
    public partial class UpDateComprasListaProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Producto_ProductoId",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_ProductoId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Compra");

            migrationBuilder.CreateTable(
                name: "CompraProducto",
                columns: table => new
                {
                    CompraId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    EstaBorrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProducto", x => new { x.CompraId, x.ProductoId });
                    table.UniqueConstraint("AK_CompraProducto_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraProducto_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraProducto_ProductoId",
                table: "CompraProducto",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraProducto");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Compra",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ProductoId",
                table: "Compra",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Producto_ProductoId",
                table: "Compra",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
