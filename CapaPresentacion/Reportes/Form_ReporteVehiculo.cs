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
    public partial class Form_ReporteVehiculo : Form
    {
        public Form_ReporteVehiculo()
        {
            InitializeComponent();
        }

        private void Form_ReporteVehiculo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_vehiculos' Puede moverla o quitarla según sea necesario.
            this.spmostrar_vehiculosTableAdapter.Fill(this.dsPrincipal.spmostrar_vehiculos);

            this.reportViewer1.RefreshReport();
        }
    }
}
