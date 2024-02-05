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
    public partial class FormReporte_ServicioFecha : Form
    {
        public FormReporte_ServicioFecha()
        {
            InitializeComponent();
        }

        private void FormReporte_ServicioFecha_Load(object sender, EventArgs e)
        {
            //try
           // {
                this.sp_mantenimiento_servicio_mes1TableAdapter.FillMesSer(this.dsPrincipal.sp_mantenimiento_servicio_mes1);
           // } catch (Exception ex) {

                this.reportViewer1.RefreshReport();
          //  }// TODO: esta línea de código carga datos en la tabla 'dsPrincipal.sp_mantenimiento_servicio_mes1' Puede moverla o quitarla según sea necesario.
            




          
        }
    }
}
