using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
   public static class VehiculoNegocio
    {
        public static EntidadVehiculo GuardarVehiculoNegocio(EntidadVehiculo vehiculo)
        {
            if (vehiculo.Id_vehiculo == 0)
            {
                return VehiculoDatos.GuardarVehiculoDatos(vehiculo);
            }
            else
            {
                return VehiculoDatos.ActualizarVehiculoDatos(vehiculo);
            }



        }

        public static List<EntidadVehiculo> DevolverListaVehiculoNegocio()
        {
            return VehiculoDatos.DevolverListaVehiculosDatos();
        }

        public static EntidadVehiculo DevolverVehiculoId(int id)
        {
            return VehiculoDatos.DevolverVehiculoId(id);
        }

        public static bool EliminarVehiculo(int id_vehiculo)
        {

            return VehiculoDatos.EliminarVehiculo(id_vehiculo);


        }
    }
}
