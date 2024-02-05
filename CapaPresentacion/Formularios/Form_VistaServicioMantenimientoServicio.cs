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
    public partial class Form_VistaServicioMantenimientoServicio : Form
    {
        public Form_VistaServicioMantenimientoServicio()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }


        //Método BuscarNombre
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dataListado.DataSource = NegocioMantenimiento.MostrarServicio_Mantenimiento_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarArticulo_Venta_Codigo()
        {
            this.dataListado.DataSource = NegocioMantenimiento.MostrarServicio_Mantenimiento_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Id"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FormMantenimiento form = FormMantenimiento.GetInstancia();
            string par1, par2, par4;
            decimal par3;
            
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombreServicio"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["costo"].Value);
            par4 = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoServicio"].Value);

            form.setServicio(par1, par2, par3, par4);
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Id"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }
    }
}
