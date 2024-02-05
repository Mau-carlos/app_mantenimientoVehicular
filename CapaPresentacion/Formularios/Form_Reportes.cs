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
    public partial class Form_Reportes : Form
    {
        public Form_Reportes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Reporte Mantenimiento Mes"))
            {
               FormReporteMantenimientoFechas frm = new FormReporteMantenimientoFechas();
              
                frm.ShowDialog();
            }
            else if (cbBuscar.Text.Equals("Reporte Empleados"))
            {

                From_ReporteE frm = new From_ReporteE();
                frm.ShowDialog();
            }
            else if (cbBuscar.Text.Equals("Reporte Servicio Mes"))
            {

                FormReporte_ServicioFecha frm = new FormReporte_ServicioFecha();
                frm.ShowDialog();
               
            }
            else if (cbBuscar.Text.Equals("Reporte Vehiculo Mes"))
            {

                Form_ReporteVehiculoMes frm = new Form_ReporteVehiculoMes();
                frm.ShowDialog();

            }
        }
    }
}
