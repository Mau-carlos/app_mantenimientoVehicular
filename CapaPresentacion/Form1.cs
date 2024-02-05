using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaEntidades;
using CapaNegocio;




namespace CapaPresentacion
{
    public partial class Form_Login : Form
    {
        EntidadEmpleado empleado = new EntidadEmpleado();
        public Form_Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        
        
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")

            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;

            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "PASSWORD")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "PASSWORD";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;

            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Realmente Desea Salir del Sistema", "Sistema de Mantenimiento Vehicular", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Opcion == DialogResult.OK)
            {
                Application.Exit();
            }

            
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text !="USUARIO")
            {
                if (txtPassword.Text !="PASSWORD")
                {
                   
                    empleado.Usuario = txtUsuario.Text;
                    empleado.Password = txtPassword.Text;
                    DataTable Datos = NegocioEmpleado.Login1(empleado);
                    //Evaluar si existe el Usuario
                    if (Datos.Rows.Count == 0)
                    {
                        //txtUsuario.Text = "USUARIO";
                        //txtUsuario.ForeColor = Color.DimGray;
                        txtPassword.Text = "PASSWORD";
                        txtPassword.ForeColor = Color.DimGray;
                        txtPassword.UseSystemPasswordChar = false;
                        msgError("Ingresó un nombre de usuario o contraseña incorrectos.\n      Por favor intente nuevamente ");
                      //  MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Mantenimiento Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                       Form_MenuPrincipal frm = new Form_MenuPrincipal();
                        frm.Nombre = Datos.Rows[0][0].ToString();
                        frm.Apellido = Datos.Rows[0][1].ToString();
                        frm.Correo = Datos.Rows[0][2].ToString();
                        frm.Cargo = Datos.Rows[0][3].ToString();
                        frm.Idtrabajador = Datos.Rows[0][4].ToString();
                       
                        frm.Show();
                        this.Hide();
                    }
                    

                }
                else
                {
                    msgError("Digite su Password");
                }
            }
            else
            {
                msgError("Digite el Usuario");
            }
        }

        private void msgError(string msg)
        {
            lbl_Error.Text = "      " + msg;
            lbl_Error.Visible = true;
        }
    }
}
