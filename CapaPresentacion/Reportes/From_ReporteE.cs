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
    public partial class From_ReporteE : Form
    {
        public From_ReporteE()
        {
            InitializeComponent();
        }

        private void From_ReporteE_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_empleado' Puede moverla o quitarla según sea necesario.
            this.spmostrar_empleadoTableAdapter.Fill(this.dsPrincipal.spmostrar_empleado);

            this.reportViewer1.RefreshReport();
        }
    }
}
