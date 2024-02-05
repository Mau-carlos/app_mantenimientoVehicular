using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntidadPerfil
    {
        public int _IdPerfil { get; set; }
        public  string _Nombre { get; set; }
        public string _Descripcion { get; set; }

        public double _Sueldo { get; set; }
        public string _TextoBuscar { get; set; }
        

       

       
        public EntidadPerfil()
        {
            
        }
        public EntidadPerfil(int idPerfil, string nombre, string descripcion, double sueldo, string textoBuscar)
        {
            _IdPerfil = idPerfil;
            _Nombre = nombre;
            _Descripcion = descripcion;
            _Sueldo = sueldo;
            _TextoBuscar = textoBuscar;
        }



    }
}
