using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonCore.Migrations
{
    public partial class UpDateIndexNombreProductoDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "Producto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "Producto");
        }
    }
}
