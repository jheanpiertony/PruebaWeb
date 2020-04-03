using Microsoft.EntityFrameworkCore.Migrations;
using CommonCore.SpSQL;

namespace CommonCore.Migrations
{
    public partial class CreacionSP_DesdeNetCoreDos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(RecursosSQLSp.CrearSpProductoPorIdDesdeNetCore_PruebaWeb_SP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(RecursosSQLSp.BorrarSpProductoPorIdDesdeNetCore_PruebaWeb_SP);
        }
    }
}
