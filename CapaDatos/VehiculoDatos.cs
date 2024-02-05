using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Properties;
using CapaEntidades;

namespace CapaDatos
{
   public static class VehiculoDatos
    {

        public static EntidadVehiculo GuardarVehiculoDatos(EntidadVehiculo vehiculo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Settings.Default.ConexionBD);
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;// aqui el propietario 
                cmd.CommandText = @" INSERT INTO [Vehiculos]    
                                                   ([Chasis]
                                                   ,[Placa]
                                                   ,[Modelo]
                                                   ,[Color]
                                                   ,[Año]
                                                   ,[Kilometraje]
                                                   ,[Estado]
                                                   )
                                             VALUES (@Chasis,@Placa,@Modelo,@Color,@Año,
                                                     @Kilometraje,@Estado)
                                               SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("@Chasis", vehiculo.Chasis);
                cmd.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                cmd.Parameters.AddWithValue("@Color", vehiculo.Color);
                cmd.Parameters.AddWithValue("@Año", vehiculo.Año);
                cmd.Parameters.AddWithValue("@Kilometraje", vehiculo.KIlometraje);
                cmd.Parameters.AddWithValue("@Estado", vehiculo.Estado);
                // cmd.Parameters.AddWithValue("@Propietario", vehiculo);

                cmd.CommandType = CommandType.Text;
                var idVechiculo = Convert.ToInt32(cmd.ExecuteScalar());
                vehiculo.Id_vehiculo = idVechiculo;
                conexion.Close();
                return vehiculo;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public static bool EliminarVehiculo(int id_vehiculo)
        {
            SqlConnection conexion = new SqlConnection(Settings.Default.ConexionBD);
            conexion.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = @"  DELETE FROM  Vehiculos WHERE id=@idVehiculo ";
            cmd.Parameters.AddWithValue("@idVehiculo", id_vehiculo);
            cmd.CommandType = CommandType.Text;
            var filasAfectadas = Convert.ToInt32(cmd.ExecuteNonQuery());
            conexion.Close();

            if (filasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static EntidadVehiculo DevolverVehiculoId(int idVehiculo)
        {
            try
            {
                EntidadVehiculo vehiculo = new EntidadVehiculo();
                SqlConnection conexion = new SqlConnection(Settings.Default.ConexionBD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = @" SELECT [Id]
                                          ,[Chasis]
                                          ,[Placa]
                                          ,[Modelo]
                                          ,[Color]
                                          ,[Año]
                                          ,[Kilometraje]
                                          ,[Estado]
                                          ,[Propietario]
                                      FROM [Vehiculos]
                                      WHERE Id=@Id
                                       ";
                cmd.Parameters.AddWithValue("@Id", idVehiculo);
                cmd.CommandType = CommandType.Text;
                using (var dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    if (dr.HasRows)
                    {
                        vehiculo.Id_vehiculo = Convert.ToInt32(dr["Id"].ToString());
                        vehiculo.Chasis = dr["Chasis"].ToString();
                        vehiculo.Placa = dr["Placa"].ToString();
                        vehiculo.Modelo = dr["Modelo"].ToString();
                        vehiculo.Color = dr["Color"].ToString();
                        vehiculo.Año = dr["Año"].ToString();
                        vehiculo.KIlometraje = Convert.ToSingle(dr["Id"].ToString());
                        vehiculo.Estado = dr["Estado"].ToString();// propietario añadir 

                    }


                }
                conexion.Close();
                return vehiculo;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<EntidadVehiculo> DevolverListaVehiculosDatos()
        {
            try
            {

                List<EntidadVehiculo> listaVehiculo = new List<EntidadVehiculo>();
                SqlConnection conexion = new SqlConnection(Settings.Default.ConexionBD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;
                cmd.CommandText = @" SELECT [Id]
                                          ,[Chasis]
                                          ,[Placa]
                                          ,[Modelo]
                                          ,[Color]
                                          ,[Año]
                                          ,[Kilometraje]
                                          ,[Estado]
                                          ,[Propietario]
                                      FROM [Vehiculos]
                                       ";
                cmd.CommandType = CommandType.Text;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EntidadVehiculo vehiculo = new EntidadVehiculo();
                        vehiculo.Id_vehiculo = Convert.ToInt32(dr["Id"].ToString());
                        vehiculo.Chasis = dr["Chasis"].ToString();
                        vehiculo.Placa = dr["Placa"].ToString();
                        vehiculo.Modelo = dr["Modelo"].ToString();
                        vehiculo.Color = dr["Color"].ToString();
                        vehiculo.Año = dr["Año"].ToString();
                        vehiculo.KIlometraje = Convert.ToSingle(dr["Id"].ToString());
                        vehiculo.Estado = dr["Estado"].ToString();// propietario añadir 
                        listaVehiculo.Add(vehiculo);
                    }
                }
                conexion.Close();
                return listaVehiculo;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public static EntidadVehiculo ActualizarVehiculoDatos(EntidadVehiculo vehiculo)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Settings.Default.ConexionBD);
                conexion.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexion;// aqui el propietario 
                cmd.CommandText = @" UPDATE [Vehiculos]
                                               SET [Chasis] =@Chasis
                                                  ,[Placa] = @Placa
                                                  ,[Modelo] = @Modelo
                                                  ,[Color] = @Color
                                                  ,[Año] = @Año
                                                  ,[Kilometraje] = @Kilometraje
                                                  ,[Estado] = @Estado                                            
                                             WHERE  Id= @Id  ";

                cmd.Parameters.AddWithValue("@Chasis", vehiculo.Chasis);
                cmd.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                cmd.Parameters.AddWithValue("@Color", vehiculo.Color);
                cmd.Parameters.AddWithValue("@Año", vehiculo.Año);
                cmd.Parameters.AddWithValue("@Kilometraje", vehiculo.KIlometraje);
                cmd.Parameters.AddWithValue("@Estado", vehiculo.Estado);
                cmd.Parameters.AddWithValue("@Id", vehiculo.Id_vehiculo);
                // cmd.Parameters.AddWithValue("@Propietario", vehiculo);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conexion.Close();
                return vehiculo;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
