using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormVista_MantenimientoVehiculo : Form
    {
        public FormVista_MantenimientoVehiculo()
        {
            InitializeComponent();
        }

        private void FormVista_MantenimientoVehiculo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NegocioVehiculo1.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarVehiculoModelo()
        {
            EntidadVehiculo1 vehiculo = new EntidadVehiculo1();
            vehiculo.TextoBuscar = this.txtBuscar.Text;
            this.dataListado.DataSource = NegocioVehiculo1.BuscarModelo(vehiculo);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void BuscarVehiculoPlaca()
        {
            EntidadVehiculo1 vehiculo = new EntidadVehiculo1();
            vehiculo.TextoBuscar = this.txtBuscar.Text;
            this.dataListado.DataSource = NegocioVehiculo1.BuscarPlaca(vehiculo);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (cbBuscar.Text.Equals("Modelo"))
            {
                this.BuscarVehiculoModelo();
            }
            else if (cbBuscar.Text.Equals("Placa"))
            {
                this.BuscarVehiculoPlaca();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Modelo"))
            {
                this.BuscarVehiculoModelo();
            }
            else if (cbBuscar.Text.Equals("Placa"))
            {
                this.BuscarVehiculoPlaca();
            }

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FormMantenimiento form = FormMantenimiento.GetInstancia();
            string par1, par2,par3;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value) + " " +
                Convert.ToString(this.dataListado.CurrentRow.Cells["modelo"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setVehiculo(par1, par2,par3);
            this.Hide();
        }
    }
}
