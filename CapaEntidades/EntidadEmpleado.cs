using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public  class EntidadEmpleado
    {
        

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        
        public string Num_Documento { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        
        public string  Correo { get; set; }

        public int idPerfil { get; set; }

        public string Usuario { get; set; }

        public string Password { get; set; }

        public string TextoBuscar { get; set; }

        public EntidadEmpleado()
        {
           
        }


        public EntidadEmpleado(int id, string nombre, string apellido, string sexo,
            DateTime fecha_nac, string num_Documento,  
              string direccion, string telefono, string correo,int idperfil,
              string usuario, string password, string textobuscar)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Sexo = sexo;
            Fecha_Nacimiento = fecha_nac;
            Num_Documento = num_Documento;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            idPerfil = idperfil;
            Usuario = usuario;
            Password = password;
            TextoBuscar = textobuscar;
        }

      
      
    }
}
