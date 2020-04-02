using Microsoft.EntityFrameworkCore.Migrations;
using CommonCore.SpSQL;

namespace CommonCore.Migrations
{
    public partial class CreacionSP_DesdeNetCoreDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var crearSPProductoPorId = RecursosSQLSp.CrearSPProductoPorId;
            migrationBuilder.Sql(RecursosSQLSp.CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var borrarSPProductoPorId = RecursosSQLSp.BorrarSPProductoPorId;
            migrationBuilder.Sql(RecursosSQLSp.CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP);
        }
    }
}
