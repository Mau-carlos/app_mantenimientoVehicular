using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntidadTipoServicio
    {
      

        public int IdTipoServicio { get; set; }
        public string Nombre { get; set; }
        public string  Descripcion { get; set; }

        public string TextoBuscar { get; set; }


        public EntidadTipoServicio()
        {
            
        }
        public EntidadTipoServicio(int idTipoServicio, string nombre, string descripcion , string textoBuscar)
        {
            IdTipoServicio = idTipoServicio;
            Nombre = nombre;
            Descripcion = descripcion;
            TextoBuscar = textoBuscar;
        }
    }
}
