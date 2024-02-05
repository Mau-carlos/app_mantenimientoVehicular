using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
     public static class NegocioMantenimiento
    {

        public static string Insertar(int idvehiculo, int idEmpleado, DateTime fecha,
           string tipo_comprobante, string serie, string correlativo, decimal igv,
           DataTable dtDetalles)
        {
            EntidadMantenimiento Obj = new EntidadMantenimiento();
            
            Obj.IdEmpleado = idEmpleado;
            Obj.IdVehiculo = idvehiculo;
            Obj.fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            List<DatosDetalleMantenimiento> detalles = new List<DatosDetalleMantenimiento>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DatosDetalleMantenimiento detalle = new DatosDetalleMantenimiento();
                detalle._IdServicio = Convert.ToInt32(row["id_Servicio"].ToString());
                detalle._Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle._Precio = Convert.ToDecimal(row["precio"].ToString());
                detalle._Descuento = Convert.ToDecimal(row["descuento"].ToString());
                detalles.Add(detalle);
            }
            return DatosMantenimiento.Insertar(Obj, detalles);
        }
        public static string Eliminar(int idmantenimiento)
        {
            EntidadMantenimiento Obj = new EntidadMantenimiento();
            Obj.IdMantenimiento = idmantenimiento;
            return DatosMantenimiento.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DVenta
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return  DatosMantenimiento.Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarFecha
        //de la clase DVenta de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            EntidadMantenimiento Obj = new EntidadMantenimiento();
            return DatosMantenimiento.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
          EntidadMantenimiento Obj = new EntidadMantenimiento();
            return DatosMantenimiento.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarServicio_Mantenimiento_Nombre(string textobuscar)
        {
          
            return DatosMantenimiento.MostrarServicio_Mantenimiento_Nombre(textobuscar);
        }
        public static DataTable MostrarServicio_Mantenimiento_Codigo(string textobuscar)
        {
           
            return DatosMantenimiento.MostrarServicio_Mantenimiento_codigo (textobuscar);
        }
    }
}
