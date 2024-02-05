using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class Form_VistaMantenimientoCliente : Form
    {
        public Form_VistaMantenimientoCliente()
        {
            InitializeComponent();
        }

        private void Form_VistaMantenimientoCliente_Load(object sender, EventArgs e)
        {
            Mostrar();
        }





        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NegocioCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellidos
        private void BuscarApellidos()
        {
            EntidadCliente1 cliente = new EntidadCliente1();
            cliente.TextoBuscar = this.txtBuscar.Text;
            this.dataListado.DataSource = NegocioCliente.BuscarApellidos(cliente);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            EntidadCliente1 cliente = new EntidadCliente1();
            cliente.TextoBuscar = this.txtBuscar.Text;
            this.dataListado.DataSource = NegocioCliente.BuscarNum_Documento(cliente);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (cbBuscar.Text.Equals("Apellido"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellido"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FormMantenimiento form = FormMantenimiento.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value) + " " +
                Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCliente(par1, par2);
            this.Hide();
        }
    }
}
