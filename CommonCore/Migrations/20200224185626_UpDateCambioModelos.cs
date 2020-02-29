using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonCore.Migrations
{
    public partial class UpDateCambioModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "PrecioUnitarioFinal",
                table: "Compra");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "CompraProducto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitarioFinal",
                table: "CompraProducto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "CompraProducto");

            migrationBuilder.DropColumn(
                name: "PrecioUnitarioFinal",
                table: "CompraProducto");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Compra",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnitarioFinal",
                table: "Compra",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
