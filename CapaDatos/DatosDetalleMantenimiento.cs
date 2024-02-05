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
   public  class DatosDetalleMantenimiento
    {
       

        public int _Iddetalle_Mantenimiento { get; set; }


        public int _IdMantenimiento { get; set; }

        public int _IdServicio { get; set; }

        public int _Cantidad { get; set; }

        public decimal _Precio { get; set; }


        public decimal _Descuento { get; set; }


        public DatosDetalleMantenimiento()
        {
           
        }



        public DatosDetalleMantenimiento(int iddetalle_venta, int idventa,
           int iddetalle_ingreso, int cantidad, decimal precio, decimal descuento)
        {
            _Iddetalle_Mantenimiento = iddetalle_venta;
            _IdMantenimiento = idventa;
            _IdServicio = iddetalle_ingreso;
            _Cantidad = cantidad;
            _Precio = precio;
            _Descuento = descuento;
        }



        //Método Insertar
        public   string Insertar(DatosDetalleMantenimiento detalle,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_mantenimiento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Venta = new SqlParameter();
                ParIddetalle_Venta.ParameterName = "@iddetalle_Mantenimiento";
                ParIddetalle_Venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_Venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Venta);

                SqlParameter ParIdMantenimiento = new SqlParameter();
                ParIdMantenimiento.ParameterName = "@idmantenimiento";
                ParIdMantenimiento.SqlDbType = SqlDbType.Int;
                ParIdMantenimiento.Value = detalle._IdMantenimiento;
                SqlCmd.Parameters.Add(ParIdMantenimiento);

                SqlParameter ParId_Servicio = new SqlParameter();
                ParId_Servicio.ParameterName = "@id_servicio";
                ParId_Servicio.SqlDbType = SqlDbType.Int;
                ParId_Servicio.Value = detalle._IdServicio;
                SqlCmd.Parameters.Add(ParId_Servicio);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = detalle._Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = detalle._Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = detalle._Descuento;
                SqlCmd.Parameters.Add(ParDescuento);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }
    }
}
