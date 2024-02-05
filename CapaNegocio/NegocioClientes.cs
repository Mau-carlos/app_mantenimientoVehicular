using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public static class NegocioClientes
    {
        public static EntidadCliente GuardarClienteN(EntidadCliente cliente)
        {
            if (cliente.Id == 0)
            {
                return DatosCliente.GuardarClienteD(cliente);
            }
            else
            {
                return DatosCliente.ActualizarClienteD(cliente);
            }
        }

        public static object RetornarClientesN()
        {
            return DatosCliente.RetornarClientesD();
        }

        public static EntidadCliente CargarClientesIDN(int id)
        {
            return DatosCliente.CargarClienteIDD(id);
        }

        public static bool EliminarCliente(int id)
        {
            return DatosCliente.EliminarClienteD(id);
        }

    }
}
