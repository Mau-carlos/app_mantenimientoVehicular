using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public static class NegocioVehiculo1
    {

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(EntidadVehiculo1 vehiculo)
        {
           
            return DatosVehiculo1.Insertar(vehiculo);
        }


        //Método Editar que llama al método Editar de la clase DArticulo
        //de la CapaDatos
        public static string Editar(EntidadVehiculo1 vehiculo)
        {
           
            return DatosVehiculo1.Editar(vehiculo);
        }

        //Método Eliminar que llama al método Eliminar de la clase DArticulo
        //de la CapaDatos
        public static string Eliminar(int  idvehiculo)
        {
            EntidadVehiculo1 Obj = new EntidadVehiculo1();
            Obj.Id = idvehiculo;
            return DatosVehiculo1.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DArticulo
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return  DatosVehiculo1.Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarPlaca
        //de la clase DArticulo de la CapaDatos

        public static DataTable BuscarPlaca(EntidadVehiculo1 vehiculo)
        {
           
            return DatosVehiculo1.BuscarPlaca(vehiculo);
        }


        public static DataTable BuscarModelo(EntidadVehiculo1 vehiculo)
        {

            return DatosVehiculo1.BuscarModelo(vehiculo);
        }

        public static DataTable BuscarVehiculoPropietario(EntidadVehiculo1 vehiculo)
        {

            return DatosVehiculo1.BuscarVehiculoPropietario(vehiculo);
        }

        public static DataTable BuscarVehiculoChasis(EntidadVehiculo1 vehiculo)
        {

            return DatosVehiculo1.BuscarVehiculoChasis(vehiculo);
        }

        public static DataTable BuscarVehiculoFecha(EntidadVehiculo1 vehiculo)
        {

            return DatosVehiculo1.BuscarVehiculoFecha(vehiculo);
        }
    }
}
