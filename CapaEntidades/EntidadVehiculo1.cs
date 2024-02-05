using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public  class EntidadVehiculo1
    {
        private int _Id;
        private string _Marca;
        private string _Modelo;
        private string _Color;
        private string _Placa;
        private string  _Anio;
        private string  _Chasis;
        private double _Kilometraje;
        private string _Estado;
        private int _IdCliente;
        private string _TextoBuscar;

       

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public string Placa
        {
            get { return _Placa; }
            set { _Placa = value; }
        }

        public string  Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        public string Chasis
        {
            get { return _Chasis; }
            set { _Chasis = value; }
        }

        public double Kilometraje
        {
            get { return _Kilometraje; }
            set { _Kilometraje = value; }
        }


        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public int  IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        } 

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public EntidadVehiculo1()
        {
           
        }


        public EntidadVehiculo1(int id, string marca, string modelo, string color, string placa,
           string anio, string chasis, double kilometraje, string estado, int idCliente, string textoBuscar)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Placa = placa;
            Anio = anio;
            Chasis = chasis;
            Kilometraje = kilometraje;
            Estado = estado;
            IdCliente = idCliente;
            TextoBuscar = textoBuscar;
        }

    }
}
