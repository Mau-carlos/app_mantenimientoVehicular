using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntidadDetalleMantenimiento
    {
        

        public int _Iddetalle_Mantenimiento { get; set; }
        public int _IdMantenimiento { get; set; }

        public int _Id_Servicio { get; set; }

        public int _Cantidad { get; set; }

        public decimal _Precio { get; set; }
        public decimal _Descuento { get; set; }


        public EntidadDetalleMantenimiento()
        {
           
        }

        public EntidadDetalleMantenimiento(int iddetalle_Mantenimiento, int idMantenimiento,
            int id_Servicio, int cantidad, decimal precio, decimal descuento)
        {
            _Iddetalle_Mantenimiento = iddetalle_Mantenimiento;
            _IdMantenimiento = idMantenimiento;
            _Id_Servicio = id_Servicio;
            _Cantidad = cantidad;
            _Precio = precio;
            _Descuento = descuento;
        }
    }
}
