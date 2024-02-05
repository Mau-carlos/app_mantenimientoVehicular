using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public static class NegocioTipoServicio
    {
        public static string Insertar(EntidadTipoServicio tipoServicio)
        {
           
            return DatosTipoServicio.Insertar(tipoServicio);
        }

        //Método Editar que llama al método Editar
        //de la CapaDatos
        public static string Editar(EntidadTipoServicio tipoServicio)
        {
           
            return DatosTipoServicio.Editar(tipoServicio);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(int idtipo_Servicio)
        {
            EntidadTipoServicio Obj = new EntidadTipoServicio();
            Obj.IdTipoServicio = idtipo_Servicio;
            return DatosTipoServicio.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return  DatosTipoServicio.Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            EntidadTipoServicio Obj = new EntidadTipoServicio();
            Obj.TextoBuscar = textobuscar;
            return DatosTipoServicio.BuscarNombre(Obj);
        }
    }
}
