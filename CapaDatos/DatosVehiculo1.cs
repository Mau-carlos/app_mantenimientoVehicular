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
   public static class DatosVehiculo1
    {
        public  static string Insertar(EntidadVehiculo1 vehiculo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVehiculo = new SqlParameter();
                ParIdVehiculo.ParameterName = "@id";
                ParIdVehiculo.SqlDbType = SqlDbType.Int;
                ParIdVehiculo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdVehiculo);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = vehiculo.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 50;
                ParModelo.Value = vehiculo.Modelo;
                SqlCmd.Parameters.Add(ParModelo);

                SqlParameter ParColor= new SqlParameter();
                ParColor.ParameterName = "@color";
                ParColor.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 50;
                ParColor.Value = vehiculo.Color;
                SqlCmd.Parameters.Add(ParColor);

                SqlParameter ParPlaca = new SqlParameter();
                ParPlaca.ParameterName = "@placa";
                ParPlaca.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 10;
                ParPlaca.Value = vehiculo.Placa;
                SqlCmd.Parameters.Add(ParPlaca);

                SqlParameter ParAnio = new SqlParameter();
                ParAnio.ParameterName = "@anio";
                ParAnio.SqlDbType = SqlDbType.VarChar;
                ParAnio.Size = 4;
                ParAnio.Value = vehiculo.Anio;
                SqlCmd.Parameters.Add(ParAnio);

                SqlParameter ParChasis = new SqlParameter();
                ParChasis.ParameterName = "@chasis";
                ParChasis.SqlDbType = SqlDbType.VarChar;
                ParChasis.Size = 20;
                ParChasis.Value = vehiculo.Chasis;
                SqlCmd.Parameters.Add(ParChasis);

                SqlParameter ParKilometraje = new SqlParameter();
                ParKilometraje.ParameterName = "@kilometraje";
                ParKilometraje.SqlDbType = SqlDbType.Float;
                //ParKilometraje.Size = 20;
                ParKilometraje.Value = vehiculo.Kilometraje;
                SqlCmd.Parameters.Add(ParKilometraje);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 50;
                ParEstado.Value = vehiculo.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.VarChar;
                ParIdCliente.Value =vehiculo.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }



        public static string Editar(EntidadVehiculo1 vehiculo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVehiculo = new SqlParameter();
                ParIdVehiculo.ParameterName = "@idvehiculo";
                ParIdVehiculo.SqlDbType = SqlDbType.Int;
                ParIdVehiculo.Value = vehiculo.Id;
                SqlCmd.Parameters.Add(ParIdVehiculo);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = vehiculo.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 50;
                ParModelo.Value = vehiculo.Modelo;
                SqlCmd.Parameters.Add(ParModelo);

                SqlParameter ParColor = new SqlParameter();
                ParColor.ParameterName = "@color";
                ParColor.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 50;
                ParColor.Value = vehiculo.Color;
                SqlCmd.Parameters.Add(ParColor);

                SqlParameter ParPlaca = new SqlParameter();
                ParPlaca.ParameterName = "@placa";
                ParPlaca.SqlDbType = SqlDbType.VarChar;
                ParColor.Size = 10;
                ParPlaca.Value = vehiculo.Placa;
                SqlCmd.Parameters.Add(ParPlaca);

                SqlParameter ParAnio = new SqlParameter();
                ParAnio.ParameterName = "@anio";
                ParAnio.SqlDbType = SqlDbType.VarChar;
                ParAnio.Size = 4;
                ParAnio.Value = vehiculo.Anio;
                SqlCmd.Parameters.Add(ParAnio);

                SqlParameter ParChasis = new SqlParameter();
                ParChasis.ParameterName = "@chasis";
                ParChasis.SqlDbType = SqlDbType.VarChar;
                ParChasis.Size = 20;
                ParChasis.Value = vehiculo.Chasis;
                SqlCmd.Parameters.Add(ParChasis);

                SqlParameter ParKilometraje = new SqlParameter();
                ParKilometraje.ParameterName = "@kilometraje";
                ParKilometraje.SqlDbType = SqlDbType.Float;
                //ParKilometraje.Size = 20;
                ParKilometraje.Value = vehiculo.Kilometraje;
                SqlCmd.Parameters.Add(ParKilometraje);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 50;
                ParEstado.Value = vehiculo.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.VarChar;
                ParIdCliente.Value = vehiculo.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Eliminar
        public static  string Eliminar(EntidadVehiculo1 vehiculo)
        {

            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_vehiculo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVehiculo = new SqlParameter();
                ParIdVehiculo.ParameterName = "@idvehiculo";
                ParIdVehiculo.SqlDbType = SqlDbType.Int;
                ParIdVehiculo.Value = vehiculo.Id;
                SqlCmd.Parameters.Add(ParIdVehiculo);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


        //Método Mostrar
        public static  DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_vehiculos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //Método BuscarNombre
        public static  DataTable BuscarPlaca(EntidadVehiculo1 vehiculo)
        {
            DataTable DtResultado = new DataTable("vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_vehiculo_placa";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = vehiculo.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        public static DataTable BuscarModelo(EntidadVehiculo1 vehiculo)
        {
            DataTable DtResultado = new DataTable("vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_vehiculo_modelo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = vehiculo.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }



        public static DataTable BuscarVehiculoPropietario(EntidadVehiculo1 vehiculo)
        {
            DataTable DtResultado = new DataTable("vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_vehiculo_propietario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = vehiculo.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        public static DataTable BuscarVehiculoChasis(EntidadVehiculo1 vehiculo)
        {
            DataTable DtResultado = new DataTable("vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_vehiculo_chasis";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = vehiculo.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public static DataTable BuscarVehiculoFecha(EntidadVehiculo1 vehiculo)
        {
            DataTable DtResultado = new DataTable("vehiculo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_vehiculo_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = vehiculo.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
