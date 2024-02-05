using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocio
{
    public static class NegocioEmpleado
    {
        public static string Insertar(EntidadEmpleado empleado)
        {
            

            return DatosEmpleado.Insertar(empleado);
        }

        //Método Editar que llama al método Editar de la clase DTrabajador
        //de la CapaDatos
        public static string Editar(EntidadEmpleado empleado)
        {
           
            return DatosEmpleado.Editar(empleado);
        }

        //Método Eliminar que llama al método Eliminar de la clase DTrabajador
        //de la CapaDatos
        public static string Eliminar(int idtrabajador)
        {
            EntidadEmpleado empleado = new EntidadEmpleado();
            empleado.Id = idtrabajador;
            return DatosEmpleado.Eliminar(empleado);
        }

        //Método Mostrar que llama al método Mostrar de la clase DTrabajador
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return  DatosEmpleado.Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DTrabajador de la CapaDatos

        public static DataTable BuscarApellidos(string textobuscar)
        {
            EntidadEmpleado Obj = new EntidadEmpleado();
            Obj.TextoBuscar = textobuscar;
            return DatosEmpleado.BuscarApellidos(Obj);
        }

        //Método BuscarNum_Documento que llama al método BuscarNum_Documento
        //de la clase DTRabajador de la CapaDatos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            EntidadEmpleado Obj = new EntidadEmpleado();
            Obj.TextoBuscar = textobuscar;
            return DatosEmpleado.BuscarNum_Documento(Obj);
        }
        public static DataTable Login1(EntidadEmpleado empleado)
        {
            return DatosEmpleado.Login1(empleado); 
            
        }
    }
}
