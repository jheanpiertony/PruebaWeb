using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CommonCore.Repositories
{
    public class ADORepositorio : IADORepositorio
    {
        private IConfiguration _configuration;

        public ADORepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Producto>> ObtenerListadoProductos()
        {
            var productos = new List<Producto>();
            string query = $@"SELECT * FROM Producto";//ATENCION este string
            string cadenaConexion = _configuration.GetConnectionString("DefaultConnection");

            using (var conexionSql = new SqlConnection(cadenaConexion))
            {
                using (var cmd = new SqlCommand(query, conexionSql))
                {
                    await conexionSql.OpenAsync();

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                    
                    dataAdapter.Fill(dataTable);
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        productos.Add(MapToValue(reader));
                    }
                }
            }
            return productos;
        }
        private Producto MapToValue(SqlDataReader reader)
        {
            /* var Id = (int)reader["Id"];
            var Nombres = reader["Nombres"].ToString();
            var Apellidos = reader["Apellidos"].ToString();
            var FechaNacimiento = (DateTime)reader["FechaNacimiento"];
            var UrlFoto = reader["UrlFoto"].ToString();
            var Sexo = (Sexo)reader["Sexo"]; */

            var producto = new Producto()
            {
                Id = (int)reader["Id"],
                EstaBorrado = (bool)reader["EstaBorrado"],
                ImagenURL = reader["ImagenURL"].ToString(),
                NombreProducto = reader["NombreProducto"].ToString(),
                Precio = (Decimal)reader["Precio"],
            };
            return producto;
        }
    }
}
