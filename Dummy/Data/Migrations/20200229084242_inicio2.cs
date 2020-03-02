using Microsoft.EntityFrameworkCore.Migrations;

namespace Dummy.Data.Migrations
{
    public partial class inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "SubCategorias",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "SubCategorias",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
