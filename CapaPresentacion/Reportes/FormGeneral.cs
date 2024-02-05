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
    public partial class FormGeneral : Form
    {
        public FormGeneral()
        {
            InitializeComponent();
        }

        private void FormGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                this.spreporte_factura_generalTableAdapter.Fill(this.dsPrincipal.spreporte_factura_general);
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spreporte_factura_general' Puede moverla o quitarla según sea necesario.
           

           
        }
    }
}
