using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public  class EntidadVehiculo
    {
        public int Id_vehiculo { get; set; }
        public string Chasis { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Año { get; set; }
        public float KIlometraje { get; set; }
        public string Estado { get; set; }



        public EntidadVehiculo()
        {

        }

        // cliente lista para la realcion 

        public EntidadVehiculo(int id_vehiculo, string chasis, string placa, string modelo, string color, string año, float kIlometraje, string estado)
        {
            Id_vehiculo = id_vehiculo;
            Chasis = chasis;
            Placa = placa;
            Modelo = modelo;
            Color = color;
            Año = año;
            KIlometraje = kIlometraje;
            Estado = estado;
        }
    }
}
