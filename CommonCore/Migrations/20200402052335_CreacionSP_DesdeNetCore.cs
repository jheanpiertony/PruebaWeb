using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CommonCore.Migrations
{
    public partial class CreacionSP_DesdeNetCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var CrearSpListaProductos = @"CREATE PROCEDURE ListadoProductoDesdeNetCore_PruebaWeb_SP
                                        AS
                                        BEGIN
                                        SET NOCOUNT ON;
                                        SELECT*
                                        FROM[dbo].Producto
                                        END";
            migrationBuilder.Sql(CrearSpListaProductos);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var BorrarSpListaProductos = @"DROP PROCEDURE ListadoProductoDesdeNetCore_PruebaWeb_SP;  
                                         GO";
            migrationBuilder.Sql(BorrarSpListaProductos);
        }
    }
}
