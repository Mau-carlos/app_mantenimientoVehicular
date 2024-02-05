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
    public partial class From_ReporteServicios : Form
    {
        public From_ReporteServicios()
        {
            InitializeComponent();
        }

        private void From_ReporteServicios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_Servicio' Puede moverla o quitarla según sea necesario.
            this.spmostrar_ServicioTableAdapter.Fill(this.dsPrincipal.spmostrar_Servicio);

            this.reportViewer1.RefreshReport();
        }
    }
}
