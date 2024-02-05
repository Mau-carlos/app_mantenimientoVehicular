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
    public partial class FormReporteMantenimientoFechas : Form
    {
        public FormReporteMantenimientoFechas()
        {
            InitializeComponent();
        }

        private void FormReporteMantenimientoFechas_Load(object sender, EventArgs e)
        {
            try
            {
                this.sp_mantenimiento_fecha_mesTableAdapter.FillMes(this.dsPrincipal.sp_mantenimiento_fecha_mes);
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.sp_mantenimiento_fecha_mes' Puede moverla o quitarla según sea necesario.
            



            
        }
    }
}
