using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonCore.Migrations
{
    public partial class UpDateCompras2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_ApplicationUserId1",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_ApplicationUserId1",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Compra");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Compra",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ApplicationUserId",
                table: "Compra",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_ApplicationUserId",
                table: "Compra",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_AspNetUsers_ApplicationUserId",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_ApplicationUserId",
                table: "Compra");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Compra",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Compra",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ApplicationUserId1",
                table: "Compra",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_AspNetUsers_ApplicationUserId1",
                table: "Compra",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
