using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CommonCore.Repositories
{
    public class ProductoRepository : IProducto
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("defaultConnection");

        public async Task<List<Producto>> OdtenerListaProducto()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ListadoProducto_PruebaWeb_SP", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    List<Producto> response = new List<Producto>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task CrearProducto(Producto producto)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CrearProducto_PruebaWeb_SP", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@EstaBorrado", producto.EstaBorrado));
                    cmd.Parameters.Add(new SqlParameter("@ImagenURL", producto.ImagenURL));
                    cmd.Parameters.Add(new SqlParameter("@NombreProducto", producto.NombreProducto));
                    cmd.Parameters.Add(new SqlParameter("@Precio", producto.Precio));
                    try
                    {
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        sql.Close();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public async Task EditarProducto(Producto producto)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("EditarProducto_PruebaWeb_SP", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", producto.Id));
                    cmd.Parameters.Add(new SqlParameter("@EstaBorrado", producto.EstaBorrado));
                    cmd.Parameters.Add(new SqlParameter("@ImagenURL", producto.ImagenURL));
                    cmd.Parameters.Add(new SqlParameter("@NombreProducto", producto.NombreProducto));
                    cmd.Parameters.Add(new SqlParameter("@Precio", producto.Precio));
                    try
                    {
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        sql.Close();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public async Task EliminarProducto(int id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ElimarProducto_PruebaWeb_SP", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    try
                    {
                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        sql.Close();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private Producto MapToValue(SqlDataReader reader)
        {
            //var Id = (int)reader["Id"];
            //var Nombres = reader["Nombres"].ToString();
            //var Apellidos = reader["Apellidos"].ToString();
            //var FechaNacimiento = (DateTime)reader["FechaNacimiento"];
            //var UrlFoto = reader["UrlFoto"].ToString();
            //var Sexo = (Sexo)reader["Sexo"];

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
