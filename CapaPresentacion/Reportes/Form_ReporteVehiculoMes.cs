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
    public partial class Form_ReporteVehiculoMes : Form
    {
        public Form_ReporteVehiculoMes()
        {
            InitializeComponent();
        }

        private void Form_ReporteVehiculoMes_Load(object sender, EventArgs e)
        {
           // try
           /// {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.sp_mantenimiento_vehiculo_mes' Puede moverla o quitarla según sea necesario.
                this.sp_mantenimiento_vehiculo_mesTableAdapter.FillVehiculoMes(this.dsPrincipal.sp_mantenimiento_vehiculo_mes);
           // }
           // catch (Exception ex )
           // {
                this.reportViewer1.RefreshReport();
           // }
            

            
        }
    }
}
