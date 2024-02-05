using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Formularios;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Form_MenuPrincipal : Form
    {
       // private int childFormNumber = 0;
       
        public string Apellido = "";
        public string Nombre = "";
        public string Correo = "";
        public string Cargo = "";
        public string Idtrabajador = "";




        private IconButton currentBtn;
        private Panel lelfBorderBtn;
        private Form currentChildForm;

        public Form_MenuPrincipal()
        {
            InitializeComponent();
            LblHora.Text = DateTime.Now.ToString();
            lelfBorderBtn = new Panel();
            lelfBorderBtn.Size = new Size(7,60);
            panel_Menu.Controls.Add(lelfBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
           
        }

        private void cargarDatosUsuario()
        {
            label_Usuario.Text = Nombre.ToString()+"  " + Apellido.ToString();
            label_Cargo.Text = Cargo.ToString();
            label_Correo.Text = Correo.ToString();
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }



        //metodos del disenio
        private void ActivateButton( object senderBtn, Color color)
        {
            if (senderBtn !=null)
            {
                DisableButton();

                currentBtn=(IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Izquierda
                lelfBorderBtn.BackColor = color;
                lelfBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                lelfBorderBtn.Visible = true;
                lelfBorderBtn.BringToFront();

                //Icon Current 
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        
        private void OpenChildFrom(Form childFrom)
        {
            if (currentChildForm != null)
            {

                currentChildForm.Close(); 
            }
            currentChildForm = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            panel_Desktop.Controls.Add(childFrom);
            panel_Desktop.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();
            lbl_TitleChildForm.Text = childFrom.Text;
        }



       
        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildFrom(new Form_Cliente1());
        }

        private void btn_Ordenes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildFrom(new Form_Empleado());
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildFrom(new Form_Reportes());
        }
        private void btn_Vehiculos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildFrom( Form_Vehiculo1.GetInstancia());
        }

        private void btn_Cliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildFrom(FormMantenimiento.GetInstancia());
            FormMantenimiento.GetInstancia().Idtrabajador = Convert.ToInt32( Idtrabajador);

            
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildFrom(new Form_Perfiles());
        }
        
        private void btn_Configuracion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
         
           OpenChildFrom(new Form_TipoServicio());
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildFrom(new Form_Servicio());
        }
        private void btn_Home_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildFrom(new Form_Buscar());
        }
        private void Reset()
        {
            DisableButton();
            lelfBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar =IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lbl_TitleChildForm.Text = "Home";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);




        private void panel_TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
                
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

        private void btn_Restaurar_Click(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void Form_MenuPrincipal_Load(object sender, EventArgs e)
        {

            cargarDatosUsuario();
            GestionUsuario();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString();
        }


        private void GestionUsuario()
        {
            //COntrolar los accesos
            if (Cargo == "ADMINISTRADOR")
            {
                this.btn_Clientes.Enabled = true;
                this.btnServicio.Enabled = true;
                this.btn_TipoServicio.Enabled = true;
                this.btn_Mantenimiento.Enabled = true;
                this.btn_Empleados.Enabled = true;
                this.btn_PerfilesU.Enabled = true;
                this.btn_Vehiculos.Enabled = true;
                this.btnBuscar.Enabled = true;
                this.btnReportes.Enabled = true;


            }
            else if (Cargo == "Contador")
            {

                this.btn_Clientes.Enabled = true;
                this.btnServicio.Enabled = true;
                this.btn_TipoServicio.Enabled = false;
                this.btn_Mantenimiento.Enabled = false;
                this.btn_Empleados.Enabled = false;
                this.btn_PerfilesU.Enabled = true;
                this.btn_Vehiculos.Enabled = true;
                this.btnBuscar.Enabled = true;
                this.btnReportes.Enabled = true;
                

            }
            else if (Cargo == "Mecanico")
            {
                this.btn_Clientes.Enabled = false;
                this.btnServicio.Enabled = true;
                this.btn_TipoServicio.Enabled = true;
                this.btn_Mantenimiento.Enabled = true;
                this.btn_Empleados.Enabled = false;
                this.btn_PerfilesU.Enabled = false;
                this.btn_Vehiculos.Enabled = true;
                this.btnBuscar.Enabled = true;
                this.btnReportes.Enabled = false;
            }
            else 
            {
                this.btn_Clientes.Enabled = false;
                this.btnServicio.Enabled = false;
                this.btn_TipoServicio.Enabled = false;
                this.btn_Mantenimiento.Enabled = false;
                this.btn_Empleados.Enabled = false;
                this.btn_PerfilesU.Enabled = false;
                this.btn_Vehiculos.Enabled = false;
                this.btnBuscar.Enabled = false;
                this.btnReportes.Enabled = false;
            }
            
        }

    }
}
