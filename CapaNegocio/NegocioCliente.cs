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
    public static class NegocioCliente
    {
        public static string Insertar(string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            EntidadCliente1 Obj = new EntidadCliente1();
            Obj.Nombre = nombre;
            Obj.Apellido = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return DatosCliente1.Insertar(Obj);
        }

        //Método Editar que llama al método Editar de la clase DCliente
        //de la CapaDatos
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo,
            DateTime fecha_nacimiento,
            string tipo_documento, string num_documento,
            string direccion, string telefono, string email)
        {
            EntidadCliente1 Obj = new EntidadCliente1();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellido = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return DatosCliente1.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCliente
        //de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            EntidadCliente1 Obj = new EntidadCliente1();
            Obj.Idcliente = idcliente;
            return DatosCliente1.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCliente
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return  DatosCliente1.Mostrar();
        }

        //Método BuscarApellidos que llama al método BuscarApellidos
        //de la clase DCLiente de la CapaDatos


        public static DataTable BuscarApellidos(EntidadCliente1 cliente)
        {
           // EntidadCliente1 Obj = new EntidadCliente1();
           // Obj.TextoBuscar = textobuscar;
            return DatosCliente1.BuscarApellidos(cliente);
        }
        /*
    public static DataTable BuscarApellidos(string textobuscar)
    {
        EntidadCliente1 Obj = new EntidadCliente1();
        Obj.TextoBuscar = textobuscar;
        return DatosCliente1.BuscarApellidos(Obj);
    }
    */
        //Método BuscarNum_Documento que llama al método BuscarNum_Documento
        //de la clase DCliente de la CapaDatos

        public static DataTable BuscarNum_Documento(EntidadCliente1 cliente)
        {
           
            return DatosCliente1.BuscarNum_Documento(cliente);
        }
        /*
    public static DataTable BuscarNum_Documento(string textobuscar)
    {
        EntidadCliente1 Obj = new EntidadCliente1();
        Obj.TextoBuscar = textobuscar;
        return DatosCliente1.BuscarNum_Documento(Obj);
    }
    */
    }
}
