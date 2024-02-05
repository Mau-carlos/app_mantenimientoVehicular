using CapaDatos.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
   public static class DatosCliente
    {
        public static EntidadCliente GuardarClienteD(EntidadCliente cliente)
        {
            try
            {
                SqlConnection enlace = new SqlConnection(Settings.Default.ConexionBD);
                enlace.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = enlace;
                comando.CommandText = @"INSERT INTO [Cliente]
                                                       ([Cedula]
                                                       ,[Nombre]
                                                       ,[Apellido]
                                                       ,[Telefono]
                                                       ,[Direccion])
                                                 VALUES(@Cedula,@Nombre,@Apellido,@Telefono,@Direccion);
					                    SELECT SCOPE_IDENTITY()";
                comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                comando.CommandType = CommandType.Text;
                var idCliente = Convert.ToInt32(comando.ExecuteScalar());
                cliente.Id = idCliente;
                enlace.Close();
                return cliente;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public static bool EliminarClienteD(int id)
        {
            SqlConnection enlace = new SqlConnection(Settings.Default.ConexionBD);
            enlace.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = enlace;
            comando.CommandText = @"DELETE FROM [dbo].[Cliente] WHERE Id=@id";
            comando.Parameters.AddWithValue("@id", id);
            comando.CommandType = CommandType.Text;
            var filasAfectadas = Convert.ToInt32(comando.ExecuteNonQuery());
            enlace.Close();

            if (filasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static EntidadCliente CargarClienteIDD(int id)
        {
            try
            {
                EntidadCliente cliente = new EntidadCliente();
                SqlConnection enlace = new SqlConnection(Settings.Default.ConexionBD);
                enlace.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = enlace;
                comando.CommandText = @"SELECT [Id]
                                              ,[Cedula]
                                              ,[Nombre]
                                              ,[Apellido]
                                              ,[Telefono]
                                              ,[Direccion]
                                          FROM [dbo].[Cliente]
                                            WHERE Id=@Id";
                comando.Parameters.AddWithValue("@Id", id);
                comando.CommandType = CommandType.Text;
                using (var xy = comando.ExecuteReader())
                {
                    xy.Read();

                    if (xy.HasRows)
                    {
                        cliente.Id = Convert.ToInt32(xy["Id"].ToString());
                        cliente.Cedula = xy["Cedula"].ToString();
                        cliente.Nombre = xy["Nombre"].ToString();
                        cliente.Apellido = xy["Apellido"].ToString();
                        cliente.Telefono = xy["Telefono"].ToString();
                        cliente.Direccion = xy["Direccion"].ToString();
                    }
                }
                enlace.Close();
                return cliente;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static object RetornarClientesD()
        {
            try
            {
                List<EntidadCliente> lista = new List<EntidadCliente>();
                SqlConnection enlace = new SqlConnection(Settings.Default.ConexionBD);
                enlace.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = enlace;
                comando.CommandText = @"SELECT [Id]
                                              ,[Cedula]
                                              ,[Nombre]
                                              ,[Apellido]
                                              ,[Telefono]
                                              ,[Direccion]
                                          FROM [dbo].[Cliente]";
                comando.CommandType = CommandType.Text;
                using (var xy = comando.ExecuteReader())
                {
                    while (xy.Read())
                    {
                        EntidadCliente cliente = new EntidadCliente();
                        cliente.Id = Convert.ToInt32(xy["Id"].ToString());
                        cliente.Cedula = xy["Cedula"].ToString();
                        cliente.Nombre = xy["Nombre"].ToString();
                        cliente.Apellido = xy["Apellido"].ToString();
                        cliente.Telefono = xy["Telefono"].ToString();
                        cliente.Direccion = xy["Direccion"].ToString();
                        lista.Add(cliente);
                    }
                }
                enlace.Close();
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static EntidadCliente ActualizarClienteD(EntidadCliente cliente)
        {
            try
            {
                SqlConnection enlace = new SqlConnection(Settings.Default.ConexionBD);
                enlace.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = enlace;
                comando.CommandText = @"UPDATE [dbo].[Cliente]
                                               SET [Cedula] = @Cedula
                                                  ,[Nombre] = @Nombre
                                                  ,[Apellido] = @Apellido
                                                  ,[Telefono] = @Telefono
                                                  ,[Direccion] = @Direccion
                                             WHERE Id=@Id";
                comando.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@Id", cliente.Id);
                comando.CommandType = CommandType.Text;
                comando.ExecuteScalar();
                enlace.Close();
                return cliente;

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

