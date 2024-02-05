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
    public static class NegocioPerfiles
    {
        //Método Insertar que llama al método Insertar de la clase DPresentacion
        //de la CapaDatos
        public static string Insertar(EntidadPerfil perfil)
        {
            
            return DatosPerfil.Insertar(perfil);
        }

        //Método Editar que llama al método Editar de la clase DPresentacion
        //de la CapaDatos
        public static string Editar(EntidadPerfil perfil)
        {
           
            return DatosPerfil.Editar(perfil);
        }

        //Método Eliminar que llama al método Eliminar de la clase DPresentacion
        //de la CapaDatos
        public static string Eliminar(int idperfil)
        {
            EntidadPerfil Obj = new EntidadPerfil();
            Obj._IdPerfil = idperfil;
            return DatosPerfil.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DPresentacion
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return  DatosPerfil.Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DPresentacion de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            EntidadPerfil Obj = new EntidadPerfil();
            Obj._TextoBuscar = textobuscar;
            return DatosPerfil.BuscarNombre(Obj);
        }
    }
}
