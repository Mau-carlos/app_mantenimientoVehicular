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
    public partial class Form_VistaPropietario : Form
    {
        public Form_VistaPropietario()
        {
            InitializeComponent();
        }
        //Método para ocultar columnas
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


        //Método BuscarNombre
        private void BuscarNombre()
        {
            EntidadCliente1 cliente = new EntidadCliente1();
            cliente.TextoBuscar = txtBuscar.Text;
            this.dataListado.DataSource = NegocioCliente.BuscarApellidos(cliente);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void Form_VistaPropietario_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

      

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            Form_Vehiculo1 form = Form_Vehiculo1.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value) + " "+
                Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            form.setPropietario(par1, par2);
            this.Hide();
        }
    }
}
