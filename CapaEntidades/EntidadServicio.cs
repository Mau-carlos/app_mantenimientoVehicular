using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EntidadServicio
    {
       

        public int IdServicio { get; set; }

        public int Id_Tipo { get; set; }

        public string Nombre { get; set; }

        public string descripcion { get; set; }

        public decimal  Costo { get; set; }
        public string TextoBuscar { get; set; }


        public EntidadServicio()
        {
           
        }




        public EntidadServicio(int idServicio, int id_Tipo, string nombre,
            string descripcion, decimal costo, string textoBuscar)
        {
            IdServicio = idServicio;
            Id_Tipo = id_Tipo;
            Nombre = nombre;
            this.descripcion = descripcion;
            Costo = costo;
            TextoBuscar = textoBuscar;
        }
    }
}
