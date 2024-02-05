using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntidadMantenimiento
    {
        

        public int IdMantenimiento { get; set; }
        public DateTime fecha { get; set; }

        public int IdVehiculo { get; set; }
        public int IdEmpleado { get; set; }
        public string  Tipo_Comprobante { get; set; }

        public string Serie { get; set; }

        public string Correlativo { get; set; }
        public decimal Igv { get; set; }

        public DataTable dtDetalle { get; set; }


       
        public EntidadMantenimiento()
        {
           
        }
        public EntidadMantenimiento(int idMantenimiento, DateTime fecha, int idVehiculo, int idEmpleado,
            string tipo_Comprobante, string serie, string correlativo, decimal igv, DataTable DtDetalle)
        {
            IdMantenimiento = idMantenimiento;
            this.fecha = fecha;
            IdVehiculo = idVehiculo;
            IdEmpleado = idEmpleado;
            Tipo_Comprobante = tipo_Comprobante;
            Serie = serie;
            Correlativo = correlativo;
            Igv = igv;
            dtDetalle = DtDetalle;
        }
    }
}
