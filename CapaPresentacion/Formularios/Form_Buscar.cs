using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion.Formularios
{
    public partial class Form_Buscar : Form
    {
        EntidadVehiculo1 vehiculo = new EntidadVehiculo1();
        public Form_Buscar()
        {
            InitializeComponent();
            
        }
       
        private void Form_Buscar_Load(object sender, EventArgs e)
        {

        }
       
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (cbBuscar.Text.Equals("Propietario"))
            {
              
                this.BuscarVehiculo_Propietario();
            }
            else if (cbBuscar.Text.Equals("Placa"))
            {
               
                this.BuscarVehiculoPlaca();
            }
            else if (cbBuscar.Text.Equals("Chasis"))
            {
                

                this.BuscarVehiculoChasis();
            }
            

        }

        private void BuscarVehiculoChasis()
        {
            vehiculo.TextoBuscar = txtBuscar.Text;
            this.dataListado.DataSource = NegocioVehiculo1.BuscarVehiculoChasis(vehiculo);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            
            this.dataListado.Columns[10].Visible = false;
           
        }

        private void BuscarVehiculo_Propietario()
        {
            
            vehiculo.TextoBuscar = txtBuscar.Text;
            this.dataListado.DataSource = NegocioVehiculo1.BuscarVehiculoPropietario(vehiculo);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Propietario"))
            {
               
                this.BuscarVehiculo_Propietario();
            }
            else if (cbBuscar.Text.Equals("Placa"))
            {
               
                this.BuscarVehiculoPlaca();
            }
            else if (cbBuscar.Text.Equals("Chasis"))
            {
               

                this.BuscarVehiculoChasis();
            }
            

        }

        //private void BuscarVehiculoFecha()
        //{
        //    vehiculo.TextoBuscar = dtFecha.Value.ToString("dd/MM/yyyy");
        //    this.dataListado.DataSource = NegocioVehiculo1.BuscarVehiculoFecha(vehiculo);
        //    this.OcultarColumnas();
        //    lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        //}

        private void BuscarVehiculoPlaca()
        {
            vehiculo.TextoBuscar = txtBuscar.Text;
            this.dataListado.DataSource = NegocioVehiculo1.BuscarPlaca(vehiculo);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

       

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
