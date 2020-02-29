using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonCore.Migrations
{
    public partial class UpDateDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Producto",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitarioFinal",
                table: "Compra",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Producto",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioUnitarioFinal",
                table: "Compra",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");
        }
    }
}
