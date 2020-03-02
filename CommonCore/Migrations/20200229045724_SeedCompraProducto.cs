using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonCore.Migrations
{
    public partial class SeedCompraProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CompraProducto",
                columns: new[] { "CompraId", "ProductoId", "Cantidad", "EstaBorrado", "Id", "PrecioUnitarioFinal" },
                values: new object[] { 1, 1, 1, false, 1, 10000m });

            migrationBuilder.InsertData(
                table: "CompraProducto",
                columns: new[] { "CompraId", "ProductoId", "Cantidad", "EstaBorrado", "Id", "PrecioUnitarioFinal" },
                values: new object[] { 1, 2, 2, false, 2, 1100m });

            migrationBuilder.InsertData(
                table: "CompraProducto",
                columns: new[] { "CompraId", "ProductoId", "Cantidad", "EstaBorrado", "Id", "PrecioUnitarioFinal" },
                values: new object[] { 1, 4, 3, false, 3, 2200m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompraProducto",
                keyColumns: new[] { "CompraId", "ProductoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CompraProducto",
                keyColumns: new[] { "CompraId", "ProductoId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CompraProducto",
                keyColumns: new[] { "CompraId", "ProductoId" },
                keyValues: new object[] { 1, 4 });
        }
    }
}
