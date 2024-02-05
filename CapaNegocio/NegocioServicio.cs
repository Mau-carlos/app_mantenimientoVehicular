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
    public static class NegocioServicio
    {
        public static string Insertar(EntidadServicio servicio)
        {
            

            return DatosServicio.Insertar(servicio);
        }

        //Método Editar que llama al método Editar 
        //de la CapaDatos
        public static string Editar(EntidadServicio servicio)
        {
            
            return DatosServicio.Editar(servicio);
        }

        //Método Eliminar que llama al método Eliminar 
        //de la CapaDatos
        public static string Eliminar(int idarticulo)
        {
           EntidadServicio Obj = new EntidadServicio();
            Obj.IdServicio = idarticulo;
            return DatosServicio.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar 
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return DatosServicio.Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        

        public static DataTable BuscarNombre(string textobuscar)
        {
            EntidadServicio Obj = new EntidadServicio();
            Obj.TextoBuscar = textobuscar;
            return DatosServicio.BuscarNombre(Obj);
        }



        /*
        public static DataTable Stock_Articulos()
        {
            return new DArticulo().Stock_Articulos();
        }
        */
    }
}
