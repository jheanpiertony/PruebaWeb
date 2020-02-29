using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonCore.Migrations
{
    public partial class UpDateIndexNombreProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreProducto",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Producto_NombreProducto",
                table: "Producto",
                column: "NombreProducto",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Producto_NombreProducto",
                table: "Producto");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProducto",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
