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
   public static  class DatosServicio
    {
        public static string Insertar(EntidadServicio servicio)
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
                SqlCmd.CommandText = "spinsertar_servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdServicio = new SqlParameter();
                ParIdServicio.ParameterName = "@idservicio";
                ParIdServicio.SqlDbType = SqlDbType.Int;
                ParIdServicio.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdServicio);

                

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = servicio.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 255;
                ParDescripcion.Value = servicio.descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Money;
                ParCosto.Value = servicio.Costo;
                SqlCmd.Parameters.Add(ParCosto);

                SqlParameter ParId_TipoServicio = new SqlParameter();
                ParId_TipoServicio.ParameterName = "@idtipoServicio";
                ParId_TipoServicio.SqlDbType = SqlDbType.VarChar;
                ParId_TipoServicio.Value = servicio.Id_Tipo;
                SqlCmd.Parameters.Add(ParId_TipoServicio);

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

        //Método Editar
        public static string Editar(EntidadServicio servicio)
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
                SqlCmd.CommandText = "speditar_servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdServicio = new SqlParameter();
                ParIdServicio.ParameterName = "@idservicio";
                ParIdServicio.SqlDbType = SqlDbType.Int;
                ParIdServicio.Value = servicio.IdServicio;
                SqlCmd.Parameters.Add(ParIdServicio);

               

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = servicio.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 255;
                ParDescripcion.Value = servicio.descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParCosto = new SqlParameter();
                ParCosto.ParameterName = "@costo";
                ParCosto.SqlDbType = SqlDbType.Money;
                ParCosto.Value = servicio.Costo;
                SqlCmd.Parameters.Add(ParCosto);


                SqlParameter ParIdTipoServicio = new SqlParameter();
                ParIdTipoServicio.ParameterName = "@idtipoServicio";
                ParIdTipoServicio.SqlDbType = SqlDbType.VarChar;
                ParIdTipoServicio.Value = servicio.Id_Tipo;
                SqlCmd.Parameters.Add(ParIdTipoServicio);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";


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
        public static string Eliminar(EntidadServicio servicio)
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
                SqlCmd.CommandText = "speliminar_servicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idservicio";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = servicio.IdServicio;
                SqlCmd.Parameters.Add(ParIdarticulo);


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
        public static DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("servicio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_Servicio";
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
        public static DataTable BuscarNombre(EntidadServicio servicio)
        {
            DataTable DtResultado = new DataTable("servicio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_servicio_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = servicio.TextoBuscar;
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


        /*
        public static DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("servicio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Properties.Settings.Default.ConexionBD;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_articulos";
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
        */
    }
}
